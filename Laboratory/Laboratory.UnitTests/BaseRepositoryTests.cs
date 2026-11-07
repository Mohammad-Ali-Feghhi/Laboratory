using System;
using DataAccess.Repositories;
using DomainModel.Results;
using FluentAssertions;
using Moq;
using Xunit;

namespace Laboratory.UnitTests
{
    /// <summary>
    /// تست‌های BaseRepository - پوشش Execute و MapSqlException
    /// </summary>
    public class BaseRepositoryTests
    {
        // برای تست متدهای protected، یک کلاس مشتق شده قابل تست می‌سازیم
        private class TestableRepository : BaseRepository
        {
            public Result<T> TestExecute<T>(Func<Result<T>> action)
            {
                return Execute(action);
            }

            public Result<object> TestExecuteVoid(Action action)
            {
                return Execute(action);
            }

            // Expose MapSqlException for testing (now takes int errorNumber)
            public Result<T> TestMapSqlException<T>(int errorNumber)
            {
                return MapSqlException<T>(errorNumber);
            }
        }

        private readonly TestableRepository _repository;

        public BaseRepositoryTests()
        {
            _repository = new TestableRepository();
        }

        #region Execute Tests (Success Cases)

        [Fact]
        public void Execute_SuccessfulAction_ReturnsSuccessResult()
        {
            // Arrange
            var expectedData = "test result";

            // Act
            var result = _repository.TestExecute(() => Result<string>.Success(expectedData));

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(expectedData);
            result.ErrorCode.Should().Be(ErrorCode.None);
        }

        [Fact]
        public void Execute_ActionThrowsException_ReturnsDatabaseError()
        {
            // Arrange
            var exceptionMessage = "Unexpected error";

            // Act
            var result = _repository.TestExecute<string>(() =>
            {
                throw new Exception(exceptionMessage);
            });

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Contain("خطای دیتابیس رخ داد");
            result.Message.Should().Contain(exceptionMessage);
        }

        [Fact]
        public void ExecuteVoid_SuccessfulAction_ReturnsSuccessResult()
        {
            // Arrange
            bool actionExecuted = false;

            // Act
            var result = _repository.TestExecuteVoid(() => actionExecuted = true);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            actionExecuted.Should().BeTrue();
        }

        [Fact]
        public void ExecuteVoid_ActionThrowsException_ReturnsDatabaseError()
        {
            // Arrange
            var exceptionMessage = "Void action error";

            // Act
            var result = _repository.TestExecuteVoid(() =>
            {
                throw new Exception(exceptionMessage);
            });

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Contain("خطای دیتابیس رخ داد");
        }

        #endregion

        #region MapSqlException Tests (7 SQL Error Codes)

        [Theory]
        [InlineData(2627, "اطلاعات تکراری است. این رکورد قبلاً ثبت شده است.")] // Unique Constraint Violation (Primary Key)
        [InlineData(2601, "اطلاعات تکراری است. این رکورد قبلاً ثبت شده است.")] // Duplicate Key
        public void MapSqlException_UniqueConstraintViolation_ReturnsValidationError(int errorNumber, string expectedMessage)
        {
            // Act
            var result = _repository.TestMapSqlException<string>(errorNumber);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void MapSqlException_ForeignKeyViolation_ReturnsValidationError()
        {
            // Act
            var result = _repository.TestMapSqlException<string>(547); // Foreign Key Violation

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("عملیات نامعتبر است. اطلاعات وابسته وجود دارد.");
        }

        [Fact]
        public void MapSqlException_DeadlockVictim_ReturnsDatabaseError()
        {
            // Act
            var result = _repository.TestMapSqlException<string>(1205); // Deadlock Victim

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Be("تداخل در دسترسی به دیتابیس. لطفاً مجدداً تلاش کنید.");
        }

        [Fact]
        public void MapSqlException_Timeout_ReturnsDatabaseError()
        {
            // Act
            var result = _repository.TestMapSqlException<string>(-2); // Timeout

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Be("زمان انتظار برای پاسخ دیتابیس به پایان رسید.");
        }

        [Theory]
        [InlineData(823, "خطای دیتابیس جدی. با مدیریت سیستم تماس بگیرید.")] // I/O Error (Database Corruption)
        [InlineData(824, "خطای دیتابیس جدی. با مدیریت سیستم تماس بگیرید.")] // Logical Consistency Error
        public void MapSqlException_CriticalDatabaseError_ReturnsDatabaseError(int errorNumber, string expectedMessage)
        {
            // Act
            var result = _repository.TestMapSqlException<string>(errorNumber);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void MapSqlException_UnknownErrorCode_ReturnsGenericDatabaseError()
        {
            // Act
            var result = _repository.TestMapSqlException<string>(99999); // Unknown error code

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Be("خطای دیتابیس رخ داد (کد: 99999)");
        }

        #endregion
    }
}
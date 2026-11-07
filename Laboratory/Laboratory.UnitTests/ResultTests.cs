using System;
using DomainModel.Results;
using FluentAssertions;
using Xunit;

namespace Laboratory.UnitTests
{
    /// <summary>
    /// تست‌های کلاس Result<T> و الگوی Result Pattern
    /// </summary>
    public class ResultTests
    {
        #region Success Tests

        [Fact]
        public void Success_WithData_ReturnsSuccessResult()
        {
            // Arrange
            var testData = "test data";

            // Act
            var result = Result<string>.Success(testData);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(testData);
            result.ErrorCode.Should().Be(ErrorCode.None);
            result.Message.Should().BeEmpty();
        }

        [Fact]
        public void Success_WithNullData_ReturnsSuccessResult()
        {
            // Arrange
            string testData = null;

            // Act
            var result = Result<string>.Success(testData);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().BeNull();
            result.ErrorCode.Should().Be(ErrorCode.None);
            result.Message.Should().BeEmpty();
        }

        [Fact]
        public void Success_WithComplexObject_ReturnsSuccessResult()
        {
            // Arrange
            var testObject = new { Id = 1, Name = "Test" };

            // Act
            var result = Result<object>.Success(testObject);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be(testObject);
        }

        #endregion

        #region Fail Tests

        [Fact]
        public void Fail_WithErrorCodeAndMessage_ReturnsFailedResult()
        {
            // Arrange
            var errorCode = ErrorCode.ValidationError;
            var message = "خطای اعتبارسنجی";

            // Act
            var result = Result<string>.Fail(errorCode, message);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(errorCode);
            result.Message.Should().Be(message);
            result.Data.Should().BeNull(); // default for string
        }

        [Fact]
        public void Fail_WithDatabaseError_ReturnsFailedResult()
        {
            // Arrange
            var errorCode = ErrorCode.DatabaseError;
            var message = "خطای دیتابیس";

            // Act
            var result = Result<int>.Fail(errorCode, message);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.DatabaseError);
            result.Message.Should().Be(message);
            result.Data.Should().Be(0); // default for int
        }

        [Fact]
        public void Fail_WithUserNotFound_ReturnsFailedResult()
        {
            // Arrange
            var errorCode = ErrorCode.UserNotFound;
            var message = "کاربر یافت نشد";

            // Act
            var result = Result<string>.Fail(errorCode, message);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.UserNotFound);
            result.Message.Should().Be(message);
        }

        [Fact]
        public void Fail_WithInvalidPassword_ReturnsFailedResult()
        {
            // Arrange
            var errorCode = ErrorCode.InvalidPassword;
            var message = "رمز عبور نادرست";

            // Act
            var result = Result<string>.Fail(errorCode, message);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.InvalidPassword);
            result.Message.Should().Be(message);
        }

        [Fact]
        public void Fail_WithEmptyMessage_ReturnsFailedResultWithEmptyMessage()
        {
            // Arrange
            var errorCode = ErrorCode.ValidationError;
            var message = "";

            // Act
            var result = Result<string>.Fail(errorCode, message);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().BeEmpty();
        }

        #endregion

        #region ErrorCode Enum Tests

        [Fact]
        public void ErrorCode_None_HasValueZero()
        {
            // Act & Assert
            ((int)ErrorCode.None).Should().Be(0);
        }

        [Fact]
        public void ErrorCode_UserNotFound_HasValueOne()
        {
            // Act & Assert
            ((int)ErrorCode.UserNotFound).Should().Be(1);
        }

        [Fact]
        public void ErrorCode_InvalidPassword_HasValueTwo()
        {
            // Act & Assert
            ((int)ErrorCode.InvalidPassword).Should().Be(2);
        }

        [Fact]
        public void ErrorCode_DatabaseError_HasValueThree()
        {
            // Act & Assert
            ((int)ErrorCode.DatabaseError).Should().Be(3);
        }

        [Fact]
        public void ErrorCode_ValidationError_HasValueFour()
        {
            // Act & Assert
            ((int)ErrorCode.ValidationError).Should().Be(4);
        }

        #endregion

        #region Immutability Tests

        [Fact]
        public void Result_IsImmutable_PropertiesCannotBeChanged()
        {
            // Arrange
            var result = Result<string>.Success("initial");

            // Act & Assert
            result.IsSuccess.Should().BeTrue();
            result.Data.Should().Be("initial");
            // Properties are read-only, cannot be modified after creation
        }

        #endregion
    }
}
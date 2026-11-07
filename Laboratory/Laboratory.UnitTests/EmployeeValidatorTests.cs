using System;
using DomainModel.Models;
using DomainModel.Results;
using DomainModel.Validators;
using FluentAssertions;
using Xunit;

namespace Laboratory.UnitTests
{
    /// <summary>
    /// تست‌های اعتبارسنجی EmployeeValidator
    /// پوشش تمام سناریوهای ValidateForCreate و ValidateForUpdate
    /// </summary>
    public class EmployeeValidatorTests
    {
        #region ValidateForCreate Tests

        [Fact]
        public void ValidateForCreate_ValidEmployee_ReturnsSuccess()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15),
                IsEnabled = true,
                IsDeleted = false
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.ErrorCode.Should().Be(ErrorCode.None);
            result.Message.Should().BeEmpty();
        }

        [Fact]
        public void ValidateForCreate_NullEmployeeName_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = null,
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام و نام خانوادگی الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_EmptyEmployeeName_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام و نام خانوادگی الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_WhitespaceEmployeeName_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "   ",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام و نام خانوادگی الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_NullUsername_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = null,
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام کاربری الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_EmptyUsername_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام کاربری الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_NullPassword_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = null,
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("رمز عبور الزامی است!");
        }

        [Fact]
        public void ValidateForCreate_EmptyPassword_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("رمز عبور الزامی است!");
        }

        [Fact]
        public void ValidateForCreate_WhitespacePassword_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "   ",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("رمز عبور الزامی است!");
        }

        [Fact]
        public void ValidateForCreate_NullPhoneNumber_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = null,
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("شماره تلفن همراه الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_EmptyPhoneNumber_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("شماره تلفن همراه الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_NullAddress_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = null,
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("آدرس الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_EmptyAddress_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("آدرس الزامیست!");
        }

        [Fact]
        public void ValidateForCreate_NullBirthDate_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = null
            };

            // Act
            var result = EmployeeValidator.ValidateForCreate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("تاریخ تولد الزامیست!");
        }

        #endregion

        #region ValidateForUpdate Tests

        [Fact]
        public void ValidateForUpdate_ValidEmployee_ReturnsSuccess()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = "alireza",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15),
                IsEnabled = true,
                IsDeleted = false
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.ErrorCode.Should().Be(ErrorCode.None);
            result.Message.Should().BeEmpty();
        }

        [Fact]
        public void ValidateForUpdate_WithEmptyPassword_ReturnsSuccess()
        {
            // Arrange - Password is NOT required for Update
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "", // Password optional in Update
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.ErrorCode.Should().Be(ErrorCode.None);
        }

        [Fact]
        public void ValidateForUpdate_WithNullPassword_ReturnsSuccess()
        {
            // Arrange - Password is NOT required for Update
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = null, // Password optional in Update
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeTrue();
            result.ErrorCode.Should().Be(ErrorCode.None);
        }

        [Fact]
        public void ValidateForUpdate_NullEmployeeName_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = null,
                Username = "alireza",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام و نام خانوادگی الزامیست!");
        }

        [Fact]
        public void ValidateForUpdate_NullUsername_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = null,
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("نام کاربری الزامیست!");
        }

        [Fact]
        public void ValidateForUpdate_NullPhoneNumber_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = "alireza",
                PhoneNumber = null,
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("شماره تلفن همراه الزامیست!");
        }

        [Fact]
        public void ValidateForUpdate_NullAddress_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = "alireza",
                PhoneNumber = "09123456789",
                Address = null,
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("آدرس الزامیست!");
        }

        [Fact]
        public void ValidateForUpdate_NullBirthDate_ReturnsValidationError()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "علی محمدی",
                Username = "alireza",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = null
            };

            // Act
            var result = EmployeeValidator.ValidateForUpdate(employee);

            // Assert
            result.Should().NotBeNull();
            result.IsSuccess.Should().BeFalse();
            result.ErrorCode.Should().Be(ErrorCode.ValidationError);
            result.Message.Should().Be("تاریخ تولد الزامیست!");
        }

        #endregion

        #region ValidateDataAnnotations Tests

        [Fact]
        public void ValidateDataAnnotations_ValidEmployee_ReturnsEmptyList()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeName = "علی محمدی",
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var results = EmployeeValidator.ValidateDataAnnotations(employee);

            // Assert
            results.Should().NotBeNull();
            results.Should().BeEmpty();
        }

        [Fact]
        public void ValidateDataAnnotations_InvalidEmployee_ReturnsValidationResults()
        {
            // Arrange - EmployeeName is required and has StringLength(100)
            var employee = new Employee
            {
                EmployeeName = "", // Required attribute violation
                Username = "alireza",
                Password = "SecurePass123",
                PhoneNumber = "09123456789",
                Address = "تهران، خیابان ولیعصر",
                BirthDate = new DateTime(1990, 5, 15)
            };

            // Act
            var results = EmployeeValidator.ValidateDataAnnotations(employee);

            // Assert
            results.Should().NotBeNull();
            results.Should().NotBeEmpty();
        }

        #endregion
    }
}
using System;
using Framework;
using FluentAssertions;
using Xunit;

namespace Laboratory.UnitTests
{
    /// <summary>
    /// تست‌های HashingUtility - مستند کردن رفتار فعلی (Plain Text / Hardcoded Key)
    /// ⚠️ SEC-001: رمزها در دیتابیس به صورت Plain Text ذخیره می‌شوند
    /// ⚠️ SEC-002: کلید HMAC در کد Hardcoded است
    /// </summary>
    public class HashingUtilityTests
    {
        private readonly HashingUtility _hashingUtility;

        public HashingUtilityTests()
        {
            _hashingUtility = new HashingUtility();
        }

        #region HashPasswordWithKey Tests

        [Fact]
        public void HashPasswordWithKey_ValidPassword_ReturnsDeterministicHash()
        {
            // Arrange
            var password = "TestPassword123";

            // Act
            var hash1 = _hashingUtility.HashPasswordWithKey(password);
            var hash2 = _hashingUtility.HashPasswordWithKey(password);

            // Assert - همیشه یکسان (Deterministic)
            hash1.Should().NotBeNullOrEmpty();
            hash1.Should().Be(hash2);
        }

        [Fact]
        public void HashPasswordWithKey_SamePasswordAlwaysSameHash()
        {
            // Arrange
            var password = "MySecretPassword";

            // Act
            var hash1 = _hashingUtility.HashPasswordWithKey(password);
            var hash2 = _hashingUtility.HashPasswordWithKey(password);
            var hash3 = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash1.Should().Be(hash2);
            hash2.Should().Be(hash3);
        }

        [Fact]
        public void HashPasswordWithKey_DifferentPasswordsProduceDifferentHashes()
        {
            // Arrange
            var password1 = "Password1";
            var password2 = "Password2";

            // Act
            var hash1 = _hashingUtility.HashPasswordWithKey(password1);
            var hash2 = _hashingUtility.HashPasswordWithKey(password2);

            // Assert
            hash1.Should().NotBe(hash2);
        }

        [Fact]
        public void HashPasswordWithKey_EmptyString_ReturnsEmptyString()
        {
            // Arrange
            var password = "";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash.Should().BeEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_NullInput_ReturnsEmptyString()
        {
            // Arrange
            string password = null;

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash.Should().BeEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_WhitespaceInput_ReturnsHash()
        {
            // Arrange
            var password = "   ";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash.Should().NotBeNullOrEmpty();
            hash.Should().NotBeEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_PersianCharacters_ReturnsValidHash()
        {
            // Arrange
            var password = "رمزعبور_فارسی۱۲۳";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash.Should().NotBeNullOrEmpty();
            hash.Should().NotBeEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_SpecialCharacters_ReturnsValidHash()
        {
            // Arrange
            var password = "P@ssw0rd!#$%^&*()";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_LongPassword_ReturnsValidHash()
        {
            // Arrange
            var password = new string('a', 1000); // Very long password

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert
            hash.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_HashIsHexadecimal()
        {
            // Arrange
            var password = "TestPassword";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert - HMACSHA256 produces 32 bytes = 64 hex characters
            hash.Should().NotBeNullOrEmpty();
            hash.Length.Should().Be(64);
            hash.Should().MatchRegex("^[0-9a-f]+$"); // All lowercase hex
        }

        [Fact]
        public void HashPasswordWithKey_CaseSensitive()
        {
            // Arrange
            var password1 = "Password";
            var password2 = "password";

            // Act
            var hash1 = _hashingUtility.HashPasswordWithKey(password1);
            var hash2 = _hashingUtility.HashPasswordWithKey(password2);

            // Assert
            hash1.Should().NotBe(hash2);
        }

        #endregion

        #region Security Documentation Tests

        [Fact]
        public void HashPasswordWithKey_UsesHardcodedKey_DocumentCurrentBehavior()
        {
            // این تست مستند می‌کند که کلید Hardcoded است (SEC-002)
            // کلید در HashingUtility.cs خط 18: "b613679a0814d9ec772f95d778c35fc5ff1697c493715653c6c712144292c5ad"

            // Arrange
            var password = "TestPassword";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert - هش تولید شده باید همیشه یکسان باشد چون کلید ثابت است
            // این رفتار فعلی است که باید در آینده تغییر کند (استفاده از BCrypt و Key Rotation)
            hash.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void HashPasswordWithKey_NotUsingBCrypt_DocumentCurrentBehavior()
        {
            // این تست مستند می‌کند که BCrypt استفاده نمی‌شود (SEC-001)
            // رمز در دیتابیس به صورت Plain Text ذخیره می‌شود و Login با مقایسه مستقیم انجام می‌شود

            // Arrange
            var password = "TestPassword";

            // Act
            var hash = _hashingUtility.HashPasswordWithKey(password);

            // Assert - هش HMACSHA256 تولید می‌شود نه BCrypt
            // طول BCrypt معمولاً 60 کاراکتر است، HMACSHA256 هگز 64 کاراکتر
            hash.Length.Should().Be(64);
        }

        #endregion
    }
}
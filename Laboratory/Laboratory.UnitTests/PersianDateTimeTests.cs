using System;
using Framework;
using FluentAssertions;
using Xunit;

namespace Laboratory.UnitTests
{
    /// <summary>
    /// تست‌های PersianDateTime - تبدیل تاریخ میلادی به شمسی
    /// </summary>
    public class PersianDateTimeTests
    {
        private readonly PersianDateTime _persianDateTime;

        public PersianDateTimeTests()
        {
            _persianDateTime = new PersianDateTime();
        }

        #region GetPersianDate Tests

        [Fact]
        public void GetPersianDate_ReturnsCurrentDateInPersianFormat()
        {
            // Act
            var result = PersianDateTime.GetPersianDate();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().MatchRegex(@"^\d{4}/\d{1,2}/\d{1,2}$"); // Format: YYYY/M/D or YYYY/MM/DD
        }

        [Fact]
        public void GetPersianDate_ReturnsValidPersianYear()
        {
            // Act
            var result = PersianDateTime.GetPersianDate();

            // Assert
            var parts = result.Split('/');
            var year = int.Parse(parts[0]);

            // سال شمسی فعلی باید بین 1400 تا 1410 باشد (بسته به تاریخ اجرا)
            year.Should().BeGreaterThan(1400);
            year.Should().BeLessThan(1410);
        }

        #endregion

        #region GetPersianTime Tests

        [Fact]
        public void GetPersianTime_ReturnsCurrentTimeInPersianFormat()
        {
            // Act
            var result = PersianDateTime.GetPersianTime();

            // Assert
            result.Should().NotBeNullOrEmpty();
            // Format: H:M or HH:MM (minutes not zero-padded in implementation)
            result.Should().MatchRegex(@"^\d{1,2}:\d{1,2}$");
        }

        [Fact]
        public void GetPersianTime_ReturnsValidHourAndMinute()
        {
            // Act
            var result = PersianDateTime.GetPersianTime();

            // Assert
            var parts = result.Split(':');
            var hour = int.Parse(parts[0]);
            var minute = int.Parse(parts[1]);

            hour.Should().BeGreaterOrEqualTo(0);
            hour.Should().BeLessThan(24);
            minute.Should().BeGreaterOrEqualTo(0);
            minute.Should().BeLessThan(60);
        }

        #endregion

        #region ConvertDateTimeToPersianDateTime Tests

        [Fact]
        public void ConvertDateTimeToPersianDateTime_ValidDateTime_ReturnsPersianDate()
        {
            // Arrange
            var dateTime = new DateTime(2024, 3, 20); // 1403/1/1 (نوروز 1403)

            // Act
            var result = PersianDateTime.ConvertDateTimeToPersianDateTime(dateTime);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("1403/1/1");
        }

        [Fact]
        public void ConvertDateTimeToPersianDateTime_Nowruz_ReturnsFirstDayOfYear()
        {
            // Arrange - نوروز 1403: 20 مارس 2024
            var dateTime = new DateTime(2024, 3, 20);

            // Act
            var result = PersianDateTime.ConvertDateTimeToPersianDateTime(dateTime);

            // Assert
            result.Should().Be("1403/1/1"); // اولین روز سال 1403
        }

        [Fact]
        public void ConvertDateTimeToPersianDateTime_FirstDayOfFarvardin_Returns1403_01_01()
        {
            // Arrange - 1 فروردین 1403 = 20 مارس 2024
            var dateTime = new DateTime(2024, 3, 20);

            // Act
            var result = PersianDateTime.ConvertDateTimeToPersianDateTime(dateTime);

            // Assert
            result.Should().Be("1403/1/1");
        }

        [Fact]
        public void ConvertDateTimeToPersianDateTime_NullableDateTime_HandlesNull()
        {
            // Arrange
            DateTime? dateTime = null;

            // Act & Assert - متد فعلی null را handle نمی‌کند و InvalidOperationException می‌دهد
            // این تست رفتار فعلی را مستند می‌کند
            Action act = () => PersianDateTime.ConvertDateTimeToPersianDateTime(dateTime);
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ConvertDateTimeToPersianDateTime_VariousDates_ReturnsCorrectFormat()
        {
            // Test cases: (Gregorian, Expected Persian) - based on actual PersianCalendar behavior
            var testCases = new[]
            {
                new { Gregorian = new DateTime(2024, 1, 1), Expected = "1402/10/11" },
                new { Gregorian = new DateTime(2024, 3, 20), Expected = "1403/1/1" }, // نوروز 1403
                new { Gregorian = new DateTime(2024, 3, 21), Expected = "1403/1/2" }, // 2 فروردین
                new { Gregorian = new DateTime(2024, 6, 21), Expected = "1403/4/1" }, // 1 تیر
                new { Gregorian = new DateTime(2024, 9, 22), Expected = "1403/7/1" }, // 1 مهر
                new { Gregorian = new DateTime(2024, 12, 21), Expected = "1403/10/1" }, // 1 دی
            };

            foreach (var testCase in testCases)
            {
                // Act
                var result = PersianDateTime.ConvertDateTimeToPersianDateTime(testCase.Gregorian);

                // Assert
                result.Should().Be(testCase.Expected,
                    $"تاریخ {testCase.Gregorian:yyyy/MM/dd} باید برابر {testCase.Expected} باشد");
            }
        }

        #endregion

        #region GetAge Tests

        [Fact]
        public void GetAge_BirthDateInPast_ReturnsCorrectAge()
        {
            // Arrange - متولد 20 سال پیش
            var birthDate = DateTime.Now.AddYears(-20);

            // Act
            var age = _persianDateTime.GetAge(birthDate);

            // Assert
            age.Should().Be(20);
        }

        [Fact]
        public void GetAge_BirthDateThisYear_ReturnsZero()
        {
            // Arrange - متولد امسال
            var birthDate = DateTime.Now.AddDays(-100);

            // Act
            var age = _persianDateTime.GetAge(birthDate);

            // Assert
            age.Should().Be(0);
        }

        [Fact]
        public void GetAge_BirthDateNextYear_ReturnsNegative()
        {
            // Arrange - متولد سال آینده
            var birthDate = DateTime.Now.AddYears(1);

            // Act
            var age = _persianDateTime.GetAge(birthDate);

            // Assert
            age.Should().Be(-1);
        }

        [Fact]
        public void GetAge_LeapYearHandling_ReturnsYearDifference()
        {
            // Arrange
            var birthDate = new DateTime(2000, 2, 29); // سال کبیسه

            // Act
            // نکته: GetAge از DateTime.Now استفاده می‌کند، بنابراین برای تست دقیق
            // نیاز به refactoring متد داریم. این تست رفتار فعلی را چک می‌کند.
            var age = _persianDateTime.GetAge(birthDate);

            // Assert - فقط اختلاف سال محاسبه می‌شود (سال جاری - سال تولد)
            var expectedAge = DateTime.Now.Year - 2000;
            age.Should().Be(expectedAge);
        }

        [Fact]
        public void GetAge_DoesNotConsiderMonthDay_OnlyYearDifference()
        {
            // متد GetAge فقط تفریق سال را محاسبه می‌کند
            // الميلادي: 2024/01/01 - 2000/12/31 = 24 سال (در حالی که واقعاً 23 سال و 1 روز است)

            // Arrange
            var birthDate = new DateTime(2000, 12, 31);

            // Act
            var age = _persianDateTime.GetAge(birthDate);

            // Assert - رفتار فعلی: فقط تفریق سال
            var expectedAge = DateTime.Now.Year - 2000;
            age.Should().Be(expectedAge);
        }

        #endregion

        #region Edge Cases

        [Fact]
        public void ConvertDateTimeToPersianDateTime_MinDateTime_ThrowsOrReturnsValid()
        {
            // Arrange
            var minDate = DateTime.MinValue;

            // Act & Assert
            Action act = () => PersianDateTime.ConvertDateTimeToPersianDateTime(minDate);
            // PersianCalendar از DateTime.MinValue پشتیبانی نمی‌کند
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ConvertDateTimeToPersianDateTime_MaxDateTime_ThrowsOrReturnsValid()
        {
            // Arrange
            var maxDate = DateTime.MaxValue;

            // Act & Assert
            // PersianCalendar در .NET از DateTime.MaxValue پشتیبانی می‌کند و exception نمی‌دهد
            Action act = () => PersianDateTime.ConvertDateTimeToPersianDateTime(maxDate);
            act.Should().NotThrow();

            // و نتیجه یک تاریخ معتبر شمسی برمی‌گرداند
            var result = PersianDateTime.ConvertDateTimeToPersianDateTime(maxDate);
            result.Should().NotBeNullOrEmpty();
            result.Should().MatchRegex(@"^\d{4}/\d{1,2}/\d{1,2}$");
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeZoneTests
{
    public class ConvertTimeBySystemTimeZoneIdTests
    {
        [Fact]
        public void Should_convert_time_correctly_from_Utc_in_Moscow()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 16, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZoneId = "Utc";
            var destinationTimeZoneId = "Moscow";
            var actualResult = CustomTimeZone.ConvertTimeBySystemTimeZoneId(dateTime, sourceTimeZoneId, destinationTimeZoneId);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Utc_in_Saratov()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 17, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZoneId = "Utc";
            var destinationTimeZoneId = "Saratov";
            var actualResult = CustomTimeZone.ConvertTimeBySystemTimeZoneId(dateTime, sourceTimeZoneId, destinationTimeZoneId);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Moscow_in_Saratov()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 14, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZoneId = "Moscow";
            var destinationTimeZoneId = "Saratov";
            var actualResult = CustomTimeZone.ConvertTimeBySystemTimeZoneId(dateTime, sourceTimeZoneId, destinationTimeZoneId);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Moscow_in_Utc()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 10, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZoneId = "Moscow";
            var destinationTimeZoneId = "Utc";
            var actualResult = CustomTimeZone.ConvertTimeBySystemTimeZoneId(dateTime, sourceTimeZoneId, destinationTimeZoneId);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Saratov_in_Utc()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 09, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZoneId = "Saratov";
            var destinationTimeZoneId = "Utc";
            var actualResult = CustomTimeZone.ConvertTimeBySystemTimeZoneId(dateTime, sourceTimeZoneId, destinationTimeZoneId);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Saratov_in_Moscow()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 12, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZoneId = "Saratov";
            var destinationTimeZoneId = "Moscow";
            var actualResult = CustomTimeZone.ConvertTimeBySystemTimeZoneId(dateTime, sourceTimeZoneId, destinationTimeZoneId);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

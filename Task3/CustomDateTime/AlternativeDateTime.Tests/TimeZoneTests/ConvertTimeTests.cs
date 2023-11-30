using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeZoneTests
{
    public class ConvertTimeTests
    {
        [Fact]
        public void Should_convert_time_correctly_from_Utc_in_Moscow()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 16, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Utc;
            var destinationTimeZone = CustomTimeZone.Moscow;
            var actualResult = CustomTimeZone.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Utc_in_Saratov()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 17, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Utc;
            var destinationTimeZone = CustomTimeZone.Saratov;
            var actualResult = CustomTimeZone.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Moscow_in_Saratov()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 14, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Moscow;
            var destinationTimeZone = CustomTimeZone.Saratov;
            var actualResult = CustomTimeZone.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Moscow_in_Utc()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 10, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Moscow;
            var destinationTimeZone = CustomTimeZone.Utc;
            var actualResult = CustomTimeZone.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Saratov_in_Utc()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 09, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Saratov;
            var destinationTimeZone = CustomTimeZone.Utc;
            var actualResult = CustomTimeZone.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Saratov_in_Moscow()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 12, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Saratov;
            var destinationTimeZone = CustomTimeZone.Moscow;
            var actualResult = CustomTimeZone.ConvertTime(dateTime, sourceTimeZone, destinationTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

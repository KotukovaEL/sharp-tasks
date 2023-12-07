using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeZoneTests
{
    public class ConvertTimeToUtcTests
    {
        [Fact]
        public void Should_convert_time_correctly_from_Moscow_in_Utc()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 10, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Moscow;
            var actualResult = CustomTimeZone.ConvertTimeToUtc(dateTime, sourceTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_convert_time_correctly_from_Saratov_in_Utc()
        {
            var expectedResult = new CustomDateTime(2023, 05, 24, 09, 47, 19);
            var dateTime = new CustomDateTime(2023, 05, 24, 13, 47, 19);
            var sourceTimeZone = CustomTimeZone.Saratov;
            var actualResult = CustomTimeZone.ConvertTimeToUtc(dateTime, sourceTimeZone);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

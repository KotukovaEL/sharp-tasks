using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeSpanTests
{
    public class FromHoursTests
    {
        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_hours()
        {
            var expectedResult = new CustomTimeSpan(0, 256, 33, 21);
            var actualResult = CustomTimeSpan.FromHours(256.555871);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_hours_are_negative()
        {
            var expectedResult = new CustomTimeSpan(0, -256, -33, -21);
            var actualResult = CustomTimeSpan.FromHours(-256.555871);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

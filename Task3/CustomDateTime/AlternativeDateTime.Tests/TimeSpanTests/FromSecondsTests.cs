using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeSpanTests
{
    public class FromSecondsTests
    {
        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_seconds()
        {
            var expectedResult = new CustomTimeSpan(0, 0, 7, 27);
            var actualResult = CustomTimeSpan.FromSeconds(447);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_seconds_are_negative()
        {
            var expectedResult = new CustomTimeSpan(0, 0, -7, -27);
            var actualResult = CustomTimeSpan.FromSeconds(-447);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

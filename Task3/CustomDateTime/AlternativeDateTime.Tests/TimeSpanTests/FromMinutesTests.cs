using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeSpanTests
{
    public class FromMinutesTests
    {
        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_minutes()
        {
            var expectedResult = new CustomTimeSpan(0, 0, 48, 47);
            var actualResult = CustomTimeSpan.FromMinutes(48.78);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_minutes_is_negative()
        {
            var expectedResult = new CustomTimeSpan(0, 0, -48, -47);
            var actualResult = CustomTimeSpan.FromMinutes(-48.78);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

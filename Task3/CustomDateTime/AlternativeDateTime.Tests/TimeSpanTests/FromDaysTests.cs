using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeSpanTests
{
    public class FromDaysTests
    {
        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_days()
        {
            var expectedResult = new CustomTimeSpan(55, 10, 40, 3);
            var actualResult = CustomTimeSpan.FromDays(55.44448); 
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_calculate_customTimeSpan_when_famous_days_are_negative()
        {
            var expectedResult = new CustomTimeSpan(-55, -10, -40, -3);
            var actualResult = CustomTimeSpan.FromDays(-55.44448);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeSpanTests
{
    public class CustomTimeSpanTests
    {
        [Fact]
        public void Should_read_constructor_correctly_when_date_positive()
        {
            var expectedResult = new CustomTimeSpan(55, 13, 47, 19);
            var actualResult = new CustomTimeSpan(55, 13, 47, 19);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_read_constructor_correctly_when_date_negative()
        {
            var expectedResult = new CustomTimeSpan(-55, -13, -47, -19);
            var actualResult = new CustomTimeSpan(-55, -13, -47, -19);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_throw_ArgumentException_when_date_positive_and_negative()
        {
            Func<CustomTimeSpan> func = () => new CustomTimeSpan(55, -13, 47, -19);
            Assert.Throws<ArgumentException>(() => func());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.DateTimeTests
{
    public class CustomDateTimeTests
    {
        [Fact]
        public void Should_read_constructor_correctly_when_date_positive()
        {
            var expectedResult = new CustomDateTime(2023, 4, 55, 13, 47, 19);
            var actualResult = new CustomDateTime(2023, 4, 55, 13, 47, 19);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Should_throw_ArgumentException_when_date_negative()
        {
            Func<CustomDateTime> func = () => new CustomDateTime(2023, 4, -55, 13, 47, 19);
            Assert.Throws<ArgumentException>(() => func());
        }
    }
}

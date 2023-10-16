using AlternativeString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class IndexerPropertyTests
    {
        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_index_lower_than_0()
        {
            var customString = new CustomString("hello");
            Func<char> func = () => customString[-2];
            Assert.Throws<ArgumentOutOfRangeException>(() => func());
        }

        [Fact]
        public void Should_get_value()
        {
            var customString = new CustomString("hello");
            var actualValue = customString[2];
            var expectedValue = 'l';
            Assert.Equal(expectedValue, actualValue);   
        }

        [Fact]
        public void Should_get_value_correctly()
        {
            var customString = new CustomString("heDlo");
            var actualValue = customString[3];
            var expectedValue = 'l';
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Should_get_value_last_letter()
        {
            var customString = new CustomString("hello");
            var actualValue = customString[4];
            var expectedValue = 'o';
            Assert.Equal(expectedValue, actualValue);
        }
    }
}

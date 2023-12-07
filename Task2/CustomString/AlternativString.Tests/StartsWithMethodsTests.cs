using AlternativeString;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class StartsWithMethodsTests
    {
        [Fact]
        public void Should_return_boolean_value_correctly_when_string_contains()
        {
            var expectedResult = true;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeks");
            var result = customString1.StartsWith(customString2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_return_boolean_value_correctly_when_string_not_contains()
        {
            var expectedResult = false;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("ges");
            var result = customString1.StartsWith(customString2);
            Assert.Equal(expectedResult, result);
        }
    }
}

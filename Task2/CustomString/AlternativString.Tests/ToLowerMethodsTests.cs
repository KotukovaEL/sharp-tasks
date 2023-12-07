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
    public class ToLowerMethodsTests
    {
        [Fact]
        public void Should_convert_string_lowercase_correctly()
        {
            var expectedResult = new CustomString("geeksforgeeks");
            var customString1 = new CustomString("GeeksForGeeks");
            var result = customString1.ToLower();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

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
    public class ToUpperMethodsTests
    {
        [Fact]
        public void Should_convert_string_uppercase_correctly()
        {
            var expectedResult = new CustomString("GEEKSFORGEEKS");
            var customString1 = new CustomString("GeeksForGeeks");
            var result = customString1.ToUpper();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

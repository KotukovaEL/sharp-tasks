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
    public class CopyToMethodsTests
    {
        [Fact]
        public void Should_copy_specified_number_symbols_correctly()
        {
            var expectedResult = new CustomString("For");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.CopyTo(5,0,3);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_copy_first_symbol_correctly()
        {
            var expectedResult = new CustomString("g");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.CopyTo(0, 0, 1);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_copy_last_symbol_correctly()
        {
            var expectedResult = new CustomString("s");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.CopyTo(customString1.Length - 1, 0, 1);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

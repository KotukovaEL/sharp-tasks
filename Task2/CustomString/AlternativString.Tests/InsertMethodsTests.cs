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
    public class InsertMethodsTests
    {
        [Fact]
        public void Should_return_new_string_with_new_symbol_on_third_position_correctly()
        {
            var expectedResult = new CustomString("geeHksForGeeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Insert(3, 'H');
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_return_new_string_with_new_symbol_on_ten_position_correctly()
        {
            var expectedResult = new CustomString("geeksForGee ks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Insert(10, ' ');
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

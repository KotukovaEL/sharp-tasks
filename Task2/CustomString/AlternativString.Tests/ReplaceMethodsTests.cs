using AlternativeString;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class ReplaceMethodsTests
    {
        [Fact]
        public void Should_replace_old_symbol_with_new_symbol_correctly()
        {
            var expectedResult = new CustomString("GeekGForGeekG");
            var customString1 = new CustomString("GeeksForGeeks");
            var result = customString1.Replace('s', 'G');
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_return_string_correctly_when_not_contain_such_symbol()
        {
            var expectedResult = new CustomString("GeekGForGeekG");
            var customString1 = new CustomString("GeeksForGeeks");
            var result = customString1.Replace('l', ' ');
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

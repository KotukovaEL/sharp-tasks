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


        [Fact]
        public void Should_replace_old_string_with_new_string_correctly()
        {
            var expectedResult = new CustomString("GeeksHelloGeeks");
            var customString1 = new CustomString("GeeksForGeeks");
            var customString2 = new CustomString("For");
            var customString3 = new CustomString("Hello");
            var result = customString1.Replace(customString2, customString3);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_replace_old_string_with_new_string_correctly_when_several_old_string()
        {
            var expectedResult = new CustomString("GeeksHelloHelloGeeks");
            var customString1 = new CustomString("GeeksForForGeeks");
            var customString2 = new CustomString("For");
            var customString3 = new CustomString("Hello");
            var result = customString1.Replace(customString2, customString3);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_return_string_correctly_when_not_contain_such_string()
        {
            var expectedResult = new CustomString("GeeksForGeeks");
            var customString1 = new CustomString("GeeksForGeeks");
            var customString2 = new CustomString("World");
            var customString3 = new CustomString("Hello");
            var result = customString1.Replace(customString2, customString3);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

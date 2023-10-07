using AlternativeString;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class RemoveMethodsTests
    {
        [Fact]
        public void Should_delete_part_string_correctly()
        {
            var expectedResult = new CustomString("geeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Remove(5);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_delete_last_symbol_correctly()
        {
            var expectedResult = new CustomString("geeksForGeek");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Remove(customString1.Length - 1);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_delete_all_string_correctly()
        {
            var expectedResult = new CustomString("");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Remove(0);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_delete_first_three_symbols_correctly()
        {
            var expectedResult = new CustomString("ForGeeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Remove(0, 5);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_delete_string_leaving_first_symbol_correctly()
        {
            var expectedResult = new CustomString("g");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Remove(1, customString1.Length -1);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_delete_string_leaving_last_symbol_correctly()
        {
            var expectedResult = new CustomString("s");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Remove(0, customString1.Length - 1);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

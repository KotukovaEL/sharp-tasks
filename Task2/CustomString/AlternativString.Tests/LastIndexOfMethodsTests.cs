using AlternativeString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class LastIndexOfMethodsTests
    {
        [Fact]
        public void Should_find_symbol_index_correctly_when_it_stands_in_last_position()
        {
            var expectedIndex = 11;
            var customString1 = new CustomString("geekForGeeks");
            var result = customString1.LastIndexOf('s');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_first_occurrence_symbol_correctly_when_there_are_several_identical_symbols()
        {
            var expectedIndex = 3;
            var customString1 = new CustomString("hello");
            var result = customString1.LastIndexOf('l');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_output_value_correctly_when_no_such_symbol()
        {
            var expectedIndex = -1;
            var customString1 = new CustomString("hello");
            var result = customString1.LastIndexOf('k');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_first_occurrence_string_correctly()
        {
            var expectedIndex = 8;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("Geeks");
            var result = customString1.LastIndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_first_occurrence_string_correctly_when_there_are_several_identical_strings()
        {
            var expectedIndex = 10;
            var customString1 = new CustomString("helloworldhello");
            var customString2 = new CustomString("hello");
            var result = customString1.LastIndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_output_value_correctly_when_no_such_string()
        {
            var expectedIndex = -1;
            var customString1 = new CustomString("hello");
            var customString2 = new CustomString("world");
            var result = customString1.LastIndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }
    }
}
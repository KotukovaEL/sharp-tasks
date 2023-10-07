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
    public class IndexOfMethodsTests
    {
        [Fact]
        public void Should_find_index_symbol_correctly_when_it_stands_in_first_position()
        {
            var expectedIndex = 0;
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.IndexOf('g');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_symbol_correctly_when_it_stands_in_last_position()
        {
            var expectedIndex = 4;
            var customString1 = new CustomString("geeks");
            var result = customString1.IndexOf('s');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_first_occurrence_symbol_correctly_when_there_are_several_identical_symbols()
        {
            var expectedIndex = 2;
            var customString1 = new CustomString("hello");
            var result = customString1.IndexOf('l');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_output_value_correctly_when_no_such_symbol()
        {
            var expectedIndex = -1;
            var customString1 = new CustomString("hello");
            var result = customString1.IndexOf('k');
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_object_first_occurrence_correctly()
        {
            var expectedIndex = 0;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeks");
            var result = customString1.IndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_object_first_occurrence_correctly_when_object_located_in_middle()
        {
            var expectedIndex = 5;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("For");
            var result = customString1.IndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]

        public void Should_output_value_correctly_when_no_such_object()
        {
            var expectedIndex = -1;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("Hello");
            var result = customString1.IndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_string_first_occurrence_correctly()
        {
            var expectedIndex = 0;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = "geeks";
            var result = customString1.IndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_find_index_string_first_occurrence_correctly_when_object_located_in_middle()
        {
            var expectedIndex = 5;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = "For";
            var result = customString1.IndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }

        [Fact]

        public void Should_value_correctly_when_no_such_string()
        {
            var expectedIndex = -1;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 ="Hello";
            var result = customString1.IndexOf(customString2);
            Assert.Equal(expectedIndex, result);
        }
    }
}

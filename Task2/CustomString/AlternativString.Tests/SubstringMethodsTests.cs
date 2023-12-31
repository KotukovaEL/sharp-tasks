﻿using AlternativeString;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class SubstringMethodsTests
    {
        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_startIndex_lower_than_0()
        {
            var incorrectStartIndex = -1;
            var str = new CustomString("geeksForGeeks");

            Func<CustomString> func = () => str.Substring(incorrectStartIndex);
            Assert.Throws<ArgumentOutOfRangeException>(() => func());
        }

        [Fact]
        public void Should_throw_ArgumentOutOfRangeException_when_startIndex_more_than_char_length()
        {
            var incorrectStartIndex = 13;
            var str = new CustomString("geeksForGeeks");

            Func<CustomString> func = () => str.Substring(incorrectStartIndex);
            Assert.Throws<ArgumentOutOfRangeException>(() => func());
        }

        [Fact]
        public void Should_retrieve_substring_correctly()
        {
            var expectedResult = new CustomString("ForGeeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Substring(5);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_retrieve_last_letter_correctly()
        {
            var expectedResult = new CustomString("s");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Substring(customString1.Length - 1);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_retrieve_whole_substring_correctly()
        {
            var expectedResult = new CustomString("geeksForGeeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Substring(0);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_retrieve_substring_in_beginning_correctly()
        {
            var expectedResult = new CustomString("GeeksFor");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Substring(0, 8);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_retrieve_substring_in_middle_correctly()
        {
            var expectedResult = new CustomString("For");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Substring(5, 3);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_retrieve_substring_in_end_correctly()
        {
            var expectedResult = new CustomString("Geeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.Substring(8, 5);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

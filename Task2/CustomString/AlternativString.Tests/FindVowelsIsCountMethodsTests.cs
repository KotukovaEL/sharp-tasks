﻿using AlternativeString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativString.Tests
{
    public class FindVowelsIsCountMethodsTests
    {
        [Fact]
        public void Should_find_vowels_count_correctly()
        {
            var expectedIndex = 5;
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.FindVowelsCount();
            Assert.Equal(expectedIndex, result);
        }

        [Fact]
        public void Should_not_find_vowels_count_when_no_vowels()
        {
            var expectedIndex = 0;
            var customString1 = new CustomString("vht");
            var result = customString1.FindVowelsCount();
            Assert.Equal(expectedIndex, result);
        }
    }
}

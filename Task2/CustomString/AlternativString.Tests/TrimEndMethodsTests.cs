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
    public class TrimEndMethodsTests
    {
        [Fact]
        public void Should_delete_whitespace_in_end_string_correctly()
        {
            var expectedResult = new CustomString("geeksForGeeks");
            var customString1 = new CustomString("geeksForGeeks ");
            var result = customString1.TrimEnd();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_delete_whitespaces_in_end_string_correctly()
        {
            var expectedResult = new CustomString("geeksForGeeks");
            var customString1 = new CustomString("geeksForGeeks  ");
            var result = customString1.TrimEnd();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_return_string_correctly_when_string_not_whitespaces()
        {
            var expectedResult = new CustomString("geeksForGeeks");
            var customString1 = new CustomString("geeksForGeeks");
            var result = customString1.TrimEnd();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

using AlternativeString;
using FluentAssertions;
using System;
using Xunit;

namespace AlternativString.Tests
{
    public class ConcatMethodsTests
    {
        [Fact]
        public void Should_concat_two_objects_correctly_when_objects_are_not_equal()
        {
            var expectedResult = new CustomString("helloworld");
            var customString1 = new CustomString("hello");
            var customString2 = new CustomString("world");
            var result = customString1.Concat(customString2);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_concat_two_objects_correctly_when_objects_are_equal()
        {
            var expectedResult = new CustomString("geeksForGeeksgeeksForGeeks");
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeksForGeeks");
            var result = customString1.Concat(customString2);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_concat_two_objects_correctly_when_objects_different_lengths()
        {
            var expectedResult = new CustomString("hellopeople");
            var customString1 = new CustomString("hello");
            var customString2 = new CustomString("people");
            var result = customString1.Concat(customString2);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}


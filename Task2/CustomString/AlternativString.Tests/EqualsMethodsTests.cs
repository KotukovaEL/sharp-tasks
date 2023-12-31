using AlternativeString;
using System;
using Xunit;

namespace AlternativString.Tests
{
    public class EqualsMethodsTests
    {
        [Fact]
        public void Should_compare_two_objects_for_equality_correctly_when_objects_are_not_equal()
        {
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeks");
            var result = customString1.Equals(customString2);
            Assert.False(result);
        }

        [Fact]
        public void Should_compare_two_objects_for_equality_correctly_when_objects_are_equal()
        {
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeksForGeeks");
            var result = customString1.Equals(customString2);
            Assert.True(result);
        }
    }
}

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
    public class CompareToMethodsTests
    {
        [Fact]
        public void Should_compare_two_objects_correctly_when_one_line_longer_than_other()
        {
            var expectedResult = 1;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeks");
            var result = customString1.CompareTo(customString2);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_compare_two_objects_correctly_when_second_line_longer_than_first()
        {
            var expectedResult = -1;
            var customString1 = new CustomString("geeks");
            var customString2 = new CustomString("geeksForGeeks");
            var result = customString1.CompareTo(customString2);
            Assert.Equal(expectedResult, result);
        }

        public void Should_compare_two_objects_correctly_when_both_lines_equal()
        {
            var expectedResult = 0;
            var customString1 = new CustomString("geeksForGeeks");
            var customString2 = new CustomString("geeksForGeeks");
            var result = customString1.CompareTo(customString2);
            Assert.Equal(expectedResult, result);
        }
    }
}

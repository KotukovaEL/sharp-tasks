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
    public class DeleteVowelsMethodsTests
    {
        [Fact]
        public void Should_delete_vowels_correctly()
        {
            var expectedResult = new CustomString("hll");
            var customString1 = new CustomString("hello");
            var result = customString1.DeleteVowels();
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_calculate_quantity_vowels_correctly_when_no_vowels()
        {
            var expectedResult = new CustomString("hll");
            var customString1 = new CustomString("hll");
            var result = customString1.DeleteVowels();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

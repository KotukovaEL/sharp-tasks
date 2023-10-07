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
    public class SplitMethodsTests
    {
        [Fact]
        public void Should_split_string_correctly()
        {
            var expectedResult = "geeksForGeeks";
            var customString1 = new CustomString("geeks,For,Geeks");
            var result = customString1.Split(new[] { ',', ';', ' ' }) ;
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}

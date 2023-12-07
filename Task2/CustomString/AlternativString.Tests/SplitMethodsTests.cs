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
        public void Should_split_strings_correctly()
        {
            var expectedList = new List<CustomString>
            {
                new CustomString("geeks"),
                new CustomString("For"),
                new CustomString("Geeks"),
            };

            var customString = new CustomString("geeks,For,Geeks");
            var actualList = customString.Split(new[] { ',', ';', ' ' }) ;

            actualList.Should().BeEquivalentTo(expectedList);
        }
    }
}

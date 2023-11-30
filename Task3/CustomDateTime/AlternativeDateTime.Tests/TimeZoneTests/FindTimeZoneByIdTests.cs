using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeZoneTests
{
    public class FindTimeZoneByIdTests
    {
        [Fact]
        public void Should_find_time_zone_by_id_correctly_Utc()
        {
            var expectedResult = new CustomTimeZone("Utc", new CustomTimeSpan(0, 0, 0, 0));
            var id = "Utc";
            var actualResult = CustomTimeZone.FindTimeZoneById(id);
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_find_time_zone_by_id_correctly_Moscow()
        {
            var expectedResult = new CustomTimeZone("Moscow", new CustomTimeSpan(0, 3, 0, 0));
            var id = "Moscow";
            var actualResult = CustomTimeZone.FindTimeZoneById(id);
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_find_time_zone_by_id_correctly_Saratov()
        {
            var expectedResult = new CustomTimeZone("Saratov", new CustomTimeSpan(0, 4, 0, 0));
            var id = "Saratov";
            var actualResult = CustomTimeZone.FindTimeZoneById(id);
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_throw_ArgumentException_when_id_is_not_entered_correctly()
        { 
            Func<CustomTimeZone> func = () => CustomTimeZone.FindTimeZoneById("Saaratov");
            Assert.Throws<ArgumentException>(() => func());
        }
    }
}

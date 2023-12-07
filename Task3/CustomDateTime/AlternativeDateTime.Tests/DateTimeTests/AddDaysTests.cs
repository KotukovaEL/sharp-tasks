using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.DateTimeTests
{
    public class AddDaysTests
    {
        [Fact]
        public void Should_calculate_days_when_days_are_positive()
        {
            var expectedResult = new CustomDateTime(2023, 3, 19, 18, 49, 12);
            var td = new CustomDateTime(2023, 2, 22, 18, 49, 12);
            var result = td.AddDays(25);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_days_when_days_are_negative()
        {
            var expectedResult = new CustomDateTime(2023, 01, 28, 18, 49, 12);
            var td = new CustomDateTime(2023, 2, 22, 18, 49, 12);
            var result = td.AddDays(-25);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_days_when_days_are_positive_and_end_year()
        {
            var expectedResult = new CustomDateTime(2023, 01, 24, 18, 49, 12);
            var td = new CustomDateTime(2022, 12, 30, 18, 49, 12);
            var result = td.AddDays(25);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_days_when_days_are_negative_and_beginning_year()
        {
            var expectedResult = new CustomDateTime(2022, 12, 9, 18, 49, 12);
            var td = new CustomDateTime(2023, 01, 28, 18, 49, 12);
            var result = td.AddDays(-50);
            Assert.Equal(expectedResult, result);
        }
    }
}

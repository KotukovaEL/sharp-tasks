using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.DateTimeTests
{
    public class OperatorPlusTests
    {
        [Fact]
        public void Should_calculate_sum_when_time_spans_are_negative()
        {
            var expectedResult = new CustomDateTime(2023, 1, 29, 1, 21, 12);
            var td1 = new CustomDateTime(2023, 2, 10, 10, 5, 12);
            var ts2 = new CustomTimeSpan(-12, -8, -44, 0);
            var result = td1 + ts2;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_sum_when_time_spans_are_positive()
        {
            var expectedResult = new CustomDateTime(2023, 2, 22, 18, 49, 12);
            var td1 = new CustomDateTime(2023, 2, 10, 10, 5, 12);
            var ts2 = new CustomTimeSpan(12, 8, 44, 0);
            var result = td1 + ts2;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_sum_when_time_spans_are_negative_and_first_month()
        {
            var expectedResult = new CustomDateTime(2022, 12, 21, 1, 21, 12);
            var td1 = new CustomDateTime(2023, 01, 02, 10, 5, 12);
            var ts2 = new CustomTimeSpan(-12, -8, -44, 0);
            var result = td1 + ts2;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_sum_when_time_spans_are_positive_and_first_month()
        {
            var expectedResult = new CustomDateTime(2023, 01, 14, 18, 49, 12);
            var td1 = new CustomDateTime(2023, 01, 02, 10, 5, 12);
            var ts2 = new CustomTimeSpan(12, 8, 44, 0);
            var result = td1 + ts2;
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void Should_calculate_sum()
        {
            var expectedResult = new CustomDateTime(2023, 02, 03, 18, 38, 24);
            var td1 = new CustomDateTime(2023, 01, 01, 18, 49, 12);
            var ts2 = new CustomTimeSpan(32, 23, 49, 12);
            var result = td1 + ts2;
            Assert.Equal(expectedResult, result);
        }
    }
}

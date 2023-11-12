using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.TimeSpanTests
{
    public class OperatorMinusTests
    {
        [Fact]
        public void Should_calculate_sum_when_time_spans_are_negative()
        {
            var expectedResult = new CustomTimeSpan(1, 22, 38, 48);
            var ts1 = new CustomTimeSpan(-10, -10, -5, -12);
            var ts2 = new CustomTimeSpan(-12, -8, -44, 0);
            var result = ts1 - ts2;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_sum_when_time_spans_are_positive()
        {
            var expectedResult = new CustomTimeSpan(-1, -22, -38, -48);
            var ts1 = new CustomTimeSpan(10, 10, 5, 12);
            var ts2 = new CustomTimeSpan(12, 8, 44, 0);
            var result = ts1 - ts2;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_sum_when_time_spans_are_positive_and_negative()
        {
            var expectedResult = new CustomTimeSpan(-22, -18, -49, -12);
            var ts1 = new CustomTimeSpan(-10, -10, -5, -12);
            var ts2 = new CustomTimeSpan(12, 8, 44, 0);
            var result = ts1 - ts2;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_sum_when_time_spans_are_negative_and_positive()
        {
            var expectedResult = new CustomTimeSpan(22, 18, 49, 12);
            var ts1 = new CustomTimeSpan(10, 10, 5, 12);
            var ts2 = new CustomTimeSpan(-12, -8, -44, 0);
            var result = ts1 - ts2;
            Assert.Equal(expectedResult, result);
        }
    }
}

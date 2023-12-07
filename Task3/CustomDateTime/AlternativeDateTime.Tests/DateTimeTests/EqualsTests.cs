using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlternativeDateTime.Tests.DateTimeTests
{
    public class EqualsTests
    {
        [Fact]
        public void Should_compare_two_date_times_correctly_when_first_date_time_more_than_other()
        {
            var expectedResultBool = false;
            var td1 = new CustomDateTime(2023, 12, 10, 14, 5, 12);
            var td2 = new CustomDateTime(2022, 2, 10, 10, 5, 12);
            var result = td1.Equals(td2);
            Assert.Equal(expectedResultBool, result);
        }

        [Fact]
        public void Should_compare_two_date_times_correctly_when_first_date_time_less_than_other()
        {
            var expectedResultBool = false;
            var td1 = new CustomDateTime(2022, 12, 10, 14, 5, 12);
            var td2 = new CustomDateTime(2023, 2, 10, 10, 5, 12);
            var result = td1.Equals(td2);
            Assert.Equal(expectedResultBool, result);
        }

        [Fact]
        public void Should_compare_two_date_times_correctly_when_date_times_are_equals()
        {
            var expectedResultBool = true;
            var td1 = new CustomDateTime(2023, 2, 10, 10, 5, 12);
            var td2 = new CustomDateTime(2023, 2, 10, 10, 5, 12);
            var result = td1.Equals(td2);
            Assert.Equal(expectedResultBool, result);
        }
    }
}

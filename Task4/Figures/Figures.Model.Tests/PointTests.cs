using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Model.Tests
{
    public class PointTests
    {
        [Fact]
        public void Should_compare_points_correctly_when_first_points_not_equal_second_points_other()
        {
            var expectedResultBool = false;
            var FirstPonts = new Point { X = 3, Y = 2 };
            var SecondPonts = new Point { X = 3, Y = 3 };
            var result = FirstPonts.Equals(SecondPonts);
            Assert.Equal(expectedResultBool, result);
        }

        [Fact]
        public void Should_compare_points_correctly_when_first_points_equal_second_points_other()
        {
            var expectedResultBool = true;
            var FirstPonts = new Point { X = 3, Y = 2 };
            var SecondPonts = new Point { X = 3, Y = 2 };
            var result = FirstPonts.Equals(SecondPonts);
            Assert.Equal(expectedResultBool, result);
        }
    }
}

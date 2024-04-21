using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Model.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void Should_calculate_area()
        {
            var point1 = new Point { X = -1, Y = -3 };
            var point2 = new Point { X = -1, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            var point4 = new Point { X = 5, Y = -3 };
            var rectangle = new Rectangle { A = point1, B = point2, C = point3, D = point4 };
            var result = rectangle.GetArea();
            var expectedResult = 24;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_diameter()
        {
            var point1 = new Point { X = -1, Y = -3 };
            var point2 = new Point { X = -1, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            var point4 = new Point { X = 5, Y = -3 };
            var rectangle = new Rectangle { A = point1, B = point2, C = point3, D = point4 };
            var result = rectangle.GetDiameter();
            var expectedResult = 7.2111025509279782;
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void Should_calculate_perimeter()
        {
            var point1 = new Point { X = -1, Y = -3 };
            var point2 = new Point { X = -1, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            var point4 = new Point { X = 5, Y = -3 };
            var rectangle = new Rectangle{ A = point1, B = point2, C = point3, D = point4 };
            var result = rectangle.GetPerimeter();
            var expectedResult = 20;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_determinе_that_shape_is_a_square_correctly()
        {
            var point1 = new Point { X = 1, Y = 1 };
            var point2 = new Point { X = 1, Y = 2 };
            var point3 = new Point { X = 2, Y = 2 };
            var point4 = new Point { X = 2, Y = 1 };
            var rectangle = new Rectangle { A = point1, B = point2, C = point3, D = point4 };
            var result = rectangle.IsSquare;
            var expectedResult = true;
            Assert.Equal(expectedResult, result);
        }
    }
}

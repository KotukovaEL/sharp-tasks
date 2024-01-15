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
        public void Should_pass_validation_incorrectly()
        {
            var point1 = new Point(-1, -3);
            var point2 = new Point(-1, 1);
            var point3 = new Point(5, 1);
            var point4 = new Point(5, -4);
            Func<Rectangle> func = () => new Rectangle(point1, point2, point3, point4);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_calculate_area()
        {
            var point1 = new Point(-1, -3);
            var point2 = new Point(-1, 1);
            var point3 = new Point(5, 1);
            var point4 = new Point(5, -3);
            var rectangle = new Rectangle(point1, point2, point3, point4);
            var result = rectangle.GetArea();
            var expectedResult = 24;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_diameter()
        {
            var point1 = new Point(-1, -3);
            var point2 = new Point(-1, 1);
            var point3 = new Point(5, 1);
            var point4 = new Point(5, -3);
            var rectangle = new Rectangle(point1, point2, point3, point4);
            var result = rectangle.GetDiameter();
            var expectedResult = 7.2111025509279782;
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void Should_calculate_perimeter()
        {
            var point1 = new Point(-1, -3);
            var point2 = new Point(-1, 1);
            var point3 = new Point(5, 1);
            var point4 = new Point(5, -3);
            var rectangle = new Rectangle(point1, point2, point3, point4);
            var result = rectangle.GetPerimeter();
            var expectedResult = 20;
            Assert.Equal(expectedResult, result);
        }
    }
}

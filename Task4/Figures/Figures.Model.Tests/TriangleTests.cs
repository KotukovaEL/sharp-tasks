using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Model.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void Should_pass_validation_incorrectly()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(3, 1);
            var point3 = new Point(5, 1);
            Func<Triangle> func = () => new Triangle(point1, point2, point3);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_calculate_area()
        {
            var point1 = new Point(-1, 0);
            var point2 = new Point(1, 4);
            var point3 = new Point(3, 0);
            var triangle = new Triangle(point1, point2, point3);
            var result = triangle.GetArea();
            var expectedResult = 8;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_diameter()
        {
            var point1 = new Point(-1, 0);
            var point2 = new Point(1, 4);
            var point3 = new Point(3, 0);
            var triangle = new Triangle(point1, point2, point3);
            var result = triangle.GetDiameter();
            var expectedResult = 320.00000000000006;
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public void Should_calculate_perimeter()
        {
            var point1 = new Point(-1, 0);
            var point2 = new Point(1, 4);
            var point3 = new Point(3, 0);
            var triangle = new Triangle(point1, point2, point3);
            var result = triangle.GetPerimeter();
            var expectedResult = 12.944271909999159;
            Assert.Equal(expectedResult, result);
        }
    }
}

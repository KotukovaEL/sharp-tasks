using System;
using System.Drawing;
using Xunit;

namespace Figures.Model.Tests
{
    public class CircleTests
    {
        [Fact]
        public void Should_calculate_area()
        {
            var center = new Point { X = 3.5, Y = 3.5 };
            var radius = 5.5;
            var circle = new Circle { Center = center, Radius = radius };
            var result = circle.GetArea();
            var expectedResult = 95.033177771091232;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_diameter()
        {
            var center = new Point { X = 3.5, Y = 3.5 };
            var radius = 5.5;
            var circle = new Circle { Center = center, Radius = radius };
            var result = circle.GetDiameter();
            var expectedResult = 11;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_perimeter()
        {
            var center = new Point { X = 3.5, Y = 3.5 };
            var radius = 5.5;
            var circle = new Circle { Center = center, Radius = radius };
            var result = circle.GetPerimeter();
            var expectedResult = 34.557519189487721;
            Assert.Equal(expectedResult, result);
        }
    }
}

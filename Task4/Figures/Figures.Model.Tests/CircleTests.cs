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
            var center = new Point(3.5, 3.5);
            var radius = 5.5;
            var circle = new Circle(center, radius);
            var result = circle.GetArea();
            var expectedResult = 95.033177771091232;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_throw_ArgumentException_when_radius_is_negative_()
        {
            var center = new Point(3.5, 3.5);
            var radius = -5.5;
            Func<Circle> func = () => new Circle(center, radius);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_calculate_diameter()
        {
            var center = new Point(3.5, 3.5);
            var radius = 5.5;
            var circle = new Circle(center, radius);
            var result = circle.GetDiameter();
            var expectedResult = 11;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_perimeter()
        {
            var center = new Point(3.5, 3.5);
            var radius = 5.5;
            var circle = new Circle(center, radius);
            var result = circle.GetPerimeter();
            var expectedResult = 34.557519189487721;
            Assert.Equal(expectedResult, result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Model.Tests
{
    public class GeometricHelpersTests
    {
        [Fact]
        public void Should_calculate_side_when_coordinates_are_positive()
        {
            var point1 = new Point(3.5, 3.5);
            var point2 = new Point(5.5, 5.5);
            var result = GeometricHelpers.GetSide(point1, point2);
            var expectedResult = 2.8284271247461903;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_side_when_coordinates_are_negative()
        {
            var point1 = new Point(-3.5, -3.5);
            var point2 = new Point(-5.5, -5.5);
            var result = GeometricHelpers.GetSide(point1, point2);
            var expectedResult = 2.8284271247461903;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_angle_when_coordinates_are_negative()
        {
            var point1 = new Point(-3.5, -3.5);
            var point2 = new Point(-5.5, -5.5);
            var point3 = new Point(-7.5, -9.5);
            var result = GeometricHelpers.GetAngle(point1, point2, point3);
            var expectedResult = 1.9921251937189948;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_angle_when_coordinates_are_positive()
        {
            var point1 = new Point(3.5, 3.5);
            var point2 = new Point(5.5, 5.5);
            var point3 = new Point(7.5, 9.5);
            var result = GeometricHelpers.GetAngle(point1, point2, point3);
            var expectedResult = 1.9921251937189948;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_angle_when_right_angle()
        {
            var point1 = new Point(-1, -3);
            var point2 = new Point(-1, 1);
            var point3 = new Point(5, -3);
            var result = GeometricHelpers.GetAngle(point1, point2, point3);
            var expectedResult = 0;
            Assert.Equal(expectedResult, result);
        }
    }
}

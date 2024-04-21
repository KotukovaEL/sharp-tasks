using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Model.Tests
{
    public class RingTests
    {
        [Fact]
        public void Should_calculate_area()
        {
            var center = new Point { X = 3.5, Y = 3.5 };
            var longRadius = 5;
            var shortRadius = 3;
            var ring = new Ring { Center = center, BigCircleRadius = longRadius, SmallCircleRadius = shortRadius };
            var result = ring.GetArea();
            var expectedResult = 50.26548245743669;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_diameter()
        {
            var center = new Point { X = 3.5, Y = 3.5 };
            var longRadius = 5;
            var shortRadius = 3;
            var ring = new Ring { Center = center, BigCircleRadius = longRadius, SmallCircleRadius = shortRadius };
            var result = ring.GetDiameter();
            var expectedResult = 4;
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Should_calculate_perimeter()
        {
            var center = new Point { X = 3.5, Y = 3.5 };
            var longRadius = 5;
            var shortRadius = 3;
            var ring = new Ring { Center = center, BigCircleRadius = longRadius, SmallCircleRadius = shortRadius };
            var result = ring.GetPerimeter();
            var expectedResult = 50.26548245743669;
            Assert.Equal(expectedResult, result);
        }
    }
}

using Figures.Model;
using System;
using Xunit;

namespace Figures.Handlers.Tests
{
    public class ValidationTests
    {
        [Fact]
        public void Should_throw_ArgumentException_for_cicrle()
        { 
            var validation = new Validation();
            var radius = -5.5;
            Action func = () => validation.ValidateCircle(radius);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_throw_ArgumentException_for_lineSegment()
        {
            var validation = new Validation();
            var point1 = new Point { X = 1, Y = 1 };
            var point2 = new Point { X = 1, Y = 1 };
            Action func = () => validation.ValidateLineSegment(point1, point2);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_throw_ArgumentException_for_rectangle()
        {
            var validation = new Validation();
            var point1 = new Point { X = -1, Y = -3 };
            var point2 = new Point { X = -1, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            var point4 = new Point { X = 5, Y = -4 };
            Action func = () => validation.ValidateRectangle(point1, point2, point3, point4);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_throw_ArgumentException_for_ring()
        {
            var validation = new Validation();
            var longRadius = 3;
            var shortRadius = 5;
            Action func = () => validation.ValidateRing(longRadius, shortRadius);
            Assert.Throws<ArgumentException>(() => func());
        }

        [Fact]
        public void Should_throw_ArgumentException_for_triangle()
        {
            var validation = new Validation();
            var point1 = new Point { X = 1, Y = 1 };
            var point2 = new Point { X = 3, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            Action func = () => validation.ValidateTriangle(point1, point2, point3);
            Assert.Throws<ArgumentException>(() => func());
        }
    }
}

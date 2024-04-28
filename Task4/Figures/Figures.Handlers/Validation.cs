using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Handlers
{
    public class Validation
    {
        public void ValidateCircle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius cannot be negative");
            }
        }

        public void ValidateLineSegment(Point a, Point b)
        {
            if (a.X == b.X && a.Y == b.Y)
            {
                throw new ArgumentException("It is not a segment");
            }
        }

        public void ValidateRectangle(Point a, Point b, Point c, Point d)
        {
            var angleBAD = GeometricHelpers.GetAngle(a, b, d);
            var angleABC = GeometricHelpers.GetAngle(b, a, c);
            var angleBCD = GeometricHelpers.GetAngle(c, b, d);
            var angleCDA = GeometricHelpers.GetAngle(d, c, a);

            if (angleBAD != 0 || angleABC != 0 || angleBCD != 0 || angleCDA != 0)
            {
                throw new ArgumentException("The shape is not a rectangle or a square");
            }
        }

        public void ValidateRing(double longRadius, double shortRadius)
        {
            if (longRadius < shortRadius)
            {
                throw new ArgumentException($"LongRadius '{longRadius}' cannot be lower than shortRadius '{shortRadius}'.");
            }
        }

        public void ValidateTriangle(Point a, Point b, Point c)
        {
            if ((b.Y - a.Y) / (c.X - a.X) == (c.Y - a.X) / (b.X - a.X))
            {
                throw new ArgumentException("There is no such triangle");
            }
        }

        public void ValidateUser(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name must not empty.");
            }
        }
    }
}

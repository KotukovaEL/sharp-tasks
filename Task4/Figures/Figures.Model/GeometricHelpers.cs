using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Model
{
    public static class GeometricHelpers
    {
        public static double GetSide(Point point1, Point point2)
        {
            var xDiff = point2.X - point1.X;
            var yDiff = point2.Y - point1.Y;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public static double GetAngle(Point a, Point b, Point c)
        {
            var abX = b.X - a.X;
            var abY = b.Y - a.Y;
            var acX = c.X - a.X;
            var acY = c.Y - a.Y;

            var scalarMultiplication = (abX * acX) + (abY * acY);
            var lengthAB = Math.Sqrt(abX * abX + abY * abY);
            var lengthAD = Math.Sqrt(acX * acX + acY * acY);
            return scalarMultiplication / (Math.Abs(lengthAB) + Math.Abs(lengthAD));
        }
    }
}

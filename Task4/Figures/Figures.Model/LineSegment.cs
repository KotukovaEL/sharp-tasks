using System;
namespace Figures.Model
{
    public class LineSegment : GeometricEntity
    {
        public Point A { get; }
        public Point B { get; }

        public LineSegment(Point a, Point b)
        {
            ValidateLineSegment(a, b);
            A = a;
            B = b;
        }

        private void ValidateLineSegment(Point a, Point b)
        {
            if (a.X == b.X && a.Y == b.Y)
            {
                throw new ArgumentException("It is not a segment");
            }
        }

        public override string ToString()
        {
            return $"Id линии: {Id}. Линия: точка А: '{A.X}','{A.Y}'; точка B: '{B.X}','{B.Y}'.";
        }
    }
}

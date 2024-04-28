using System;
namespace Figures.Model
{
    public class LineSegment : GeometricEntity
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public override string ToString()
        {
            return $"Id линии: {Id}. Линия: точка А: '{A.X}','{A.Y}'; точка B: '{B.X}','{B.Y}'.";
        }
    }
}

using System;

namespace Figures.Model
{
    public class Circle : Figure
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetDiameter()
        {
            return 2 * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Id круга: {Id}. Круг: центр: '{Center.X}','{Center.Y}'; радиус: '{Radius}'. {base.ToString()}";
        }
    }
}

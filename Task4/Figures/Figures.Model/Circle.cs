using System;

namespace Figures.Model
{
    public class Circle : Figure
    {
        public Point Center { get; }
        public double Radius { get; }

        public Circle(Point center, double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException("The radius cannot be negative");
            }

            Center = center;
            Radius = radius;
        }

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
            return $"Круг: центр: '{Center.X}','{Center.Y}'; радиус: '{Radius}'. {base.ToString()}";
        }
    }
}

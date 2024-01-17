using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public class Rectangle : Figure
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }
        public Point D { get; }

        public double FirstSide { get; }
        public double SecondSide { get; }
        public bool IsSquare { get; }

        public Rectangle(Point a, Point b, Point c, Point d)
        {
            ValidateRectangle(a, b, c, d);
            A = a;
            B = b;
            C = c;
            D = d;
            FirstSide = GeometricHelpers.GetSide(a, b);
            SecondSide = GeometricHelpers.GetSide(b, c);
            IsSquare = FirstSide == SecondSide;
        }

        private void ValidateRectangle(Point a, Point b, Point c, Point d)
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

        public override double GetArea()
        {
            return FirstSide * SecondSide;
        }

        public override double GetDiameter()
        {
            return 2 * (Math.Sqrt(FirstSide * FirstSide + SecondSide * SecondSide) / 2);
        }

        public override double GetPerimeter()
        {
            return 2 * (FirstSide + SecondSide);
        }

        public override string ToString()
        {
            return $"Прямоугольник: точка А: '{A.X}','{A.Y}'; точка B: '{B.X}','{B.Y}'; точка C: '{C.X}','{C.Y}'; точка D: '{D.X}','{D.Y}'; площадь: '{GetArea()}'; периметр: '{GetPerimeter()}'; диаметр: '{GetDiameter()}'.";
        }
    }
}

using System;

namespace Figures.Model
{
    public class Rectangle : Figure
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }

        public double FirstSide => GeometricHelpers.GetSide(A, B);
        public double SecondSide => GeometricHelpers.GetSide(B, C);
        public bool IsSquare => FirstSide == SecondSide;

        public Rectangle()
        {
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
            return $"Id прямоугольника: {Id}. Прямоугольник: точка А: '{A.X}','{A.Y}'; точка B: '{B.X}','{B.Y}'; точка C: '{C.X}','{C.Y}'; точка D: '{D.X}','{D.Y}'. {base.ToString()}";
        }
    }
}

using System;

namespace Figures.Model
{
    public class Triangle : Figure
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public double SideAB => GeometricHelpers.GetSide(A, B);
        public double SideBC => GeometricHelpers.GetSide(B, C);
        public double SideAC => GeometricHelpers.GetSide(A, C);

        public override double GetArea()
        {
            var halfMeter = GetPerimeter() / 2; 
            return Math.Sqrt(halfMeter * (halfMeter - SideAB) * (halfMeter - SideBC) * (halfMeter - SideAC));
        }

        public override double GetDiameter()
        {
            return 2 * ((SideAB * SideBC * SideAC) / 4 * GetArea());
        }

        public override double GetPerimeter()
        {
            return SideAB + SideBC + SideAC;
        }

        public override string ToString()
        {
            return $"Id треугольника: {Id}. Треугольник: точка А: '{A.X}','{A.Y}'; точка B: '{B.X}','{B.Y}'; точка C: '{C.X}','{C.Y}'. {base.ToString()}";
        }
    }
}

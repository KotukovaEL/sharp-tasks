using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public class Triangle : Figure
    {
        public Point A { get; }
        public Point B { get; }
        public Point C { get; }

        public double SideAB { get; }
        public double SideBC { get; }
        public double SideAC { get; }

        public Triangle(Point a, Point b, Point c)
        {
            ValidateTriangle(a, b, c);
            A = a; 
            B = b; 
            C = c;
            SideAB = GeometricHelpers.GetSide(a, b);
            SideBC = GeometricHelpers.GetSide(b, c);
            SideAC = GeometricHelpers.GetSide(a, c);
        }

        
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

        private void ValidateTriangle(Point a, Point b, Point c)
        {
            if((b.Y - a.Y) / (c.X - a.X) == (c.Y - a.X) / (b.X - a.X))
            {
                throw new ArgumentException("There is no such triangle");
            }
        }

        public override string ToString()
        {
            return $"Id треугольника: {Id}. Треугольник: точка А: '{A.X}','{A.Y}'; точка B: '{B.X}','{B.Y}'; точка C: '{C.X}','{C.Y}'. {base.ToString()}";
        }
    }
}

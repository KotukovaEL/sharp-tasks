using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public class Point : GeometricEntity, IEquatable<Point>
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            var point = obj as Point;
            return Equals(point);
        }

        public bool Equals(Point? other)
        {
            if (other is null)
            {
                return false;
            }

            return X == other.X
                && Y == other.Y;
        }

        public override string ToString()
        {
            return $"Id точки: {Id}. Точка: координаты: '{X}','{Y}'.";
        }
    }
}

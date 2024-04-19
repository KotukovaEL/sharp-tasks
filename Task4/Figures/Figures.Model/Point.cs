using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public class Point : GeometricEntity, IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point()
        {
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

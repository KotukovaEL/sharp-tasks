using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public class Ring : Figure
    {
        public double BigCircleRadius { get; set; }
        public double SmallCircleRadius { get; set; }
        public Point Center { get; set; }

        public override double GetArea()
        {
            return Math.PI * ((BigCircleRadius * BigCircleRadius) - (SmallCircleRadius * SmallCircleRadius));
        }

        public override double GetDiameter()
        {
            return 2 * BigCircleRadius - 2 * SmallCircleRadius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * (BigCircleRadius + SmallCircleRadius);
        }

        public override string ToString()
        {
            return $"Id кольца: {Id}. Кольцо: центр: '{Center.X}','{Center.Y}'; радиус первого круга: '{BigCircleRadius}'; радиус второго круга: '{SmallCircleRadius}'. {base.ToString()}";
        }
    }
}

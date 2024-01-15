using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public class Ring : Figure
    {
        public Circle BigCircle { get; }
        public Circle SmallCircle { get; }

        public Ring(Point center, double longRadius, double shortRadius)
        {
            if (longRadius < shortRadius)
            {
                throw new ArgumentException($"LongRadius '{longRadius}' cannot be lower than shortRadius '{shortRadius}'.");
            }

            BigCircle = new Circle(center, longRadius);
            SmallCircle = new Circle(center, shortRadius);
        }


        public override double GetArea()
        {
            return BigCircle.GetArea() - SmallCircle.GetArea();
        }

        public override double GetDiameter()
        {
            return BigCircle.GetDiameter() - SmallCircle.GetDiameter();
        }

        public override double GetPerimeter()
        {
            return BigCircle.GetPerimeter() + SmallCircle.GetPerimeter();
        }
    }
}

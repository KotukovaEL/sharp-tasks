using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Model
{
    public abstract class Figure : GeometricEntity
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract double GetDiameter();
    }
}

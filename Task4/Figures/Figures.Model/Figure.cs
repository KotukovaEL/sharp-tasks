﻿using System;
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
        public override string ToString()
        {
            return $"Площадь: '{GetArea()}'. Периметр: '{GetPerimeter()}'. Диаметр: '{GetDiameter()}'.";
        }
    }
}

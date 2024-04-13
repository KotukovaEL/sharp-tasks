using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class PointDto : GeometricEntityDto
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class CircleDto : GeometricEntityDto
    {
        public PointDto Center { get; set; }
        public double Radius { get; set;  }
    }
}

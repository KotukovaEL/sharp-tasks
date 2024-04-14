using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb.DtoModels
{
    public class CircleDto : GeometricEntityDto
    {
        public PointDto Center { get; set; }
        public double Radius { get; set; }
    }
}

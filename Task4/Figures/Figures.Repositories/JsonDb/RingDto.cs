using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class RingDto : GeometricEntityDto
    {
        public PointDto Center { get; set; }
        public double LongRadius {  get; set; }
        public double ShortRadius { get; set; }
    }
}

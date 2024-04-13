using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class LineSegmentDto : GeometricEntityDto
    {
        public PointDto A { get; set; }
        public PointDto B { get; set; }
    }
}

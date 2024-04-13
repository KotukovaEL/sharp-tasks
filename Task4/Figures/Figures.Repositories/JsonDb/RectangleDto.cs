using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class RectangleDto : GeometricEntityDto
    {
        public PointDto A { get; set; }
        public PointDto B { get; set; }
        public PointDto C { get; set; }
        public PointDto D { get; set; }
    }
}

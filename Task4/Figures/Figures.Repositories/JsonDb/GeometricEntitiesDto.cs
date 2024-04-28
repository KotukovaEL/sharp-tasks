using Figures.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesDto
    {
        public List<Point> Points { get; set; } = new();
        public List<LineSegment> LineSegments { get; set; } = new();
        public List<Circle> Circles { get; set; } = new();
        public List<Rectangle> Rectangles { get; set; } = new();
        public List<Triangle> Triangles { get; set; } = new();
        public List<Ring> Rings { get; set; } = new();
    }
}

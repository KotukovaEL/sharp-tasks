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

        public GeometricEntitiesDto()
        {
        }

        public GeometricEntitiesDto(List<GeometricEntity> entities)
        {
            foreach (var entity in entities)
            {
                switch (entity)
                {
                    case Point point:
                        Points.Add(point);
                        break;
                    case LineSegment lineSegment:
                        LineSegments.Add(lineSegment);
                        break;
                    case Circle circle:
                        Circles.Add(circle);
                        break;
                    case Rectangle rectangle:
                        Rectangles.Add(rectangle);
                        break;
                    case Triangle triangle:
                        Triangles.Add(triangle);
                        break;
                    case Ring ring:
                        Rings.Add(ring);
                        break;
                    default:
                        throw new ArgumentException("There is no such figure");
                }
            }
        }

        public Dictionary<int, GeometricEntity> AddEntities()
        {
            return Enumerable.Empty<GeometricEntity>()
                .Concat(Points)
                .Concat(LineSegments)
                .Concat(Circles)
                .Concat(Triangles)
                .Concat(Rectangles)
                .Concat(Rings)
                .ToDictionary(key => key.Id);
                
        }
    }
}

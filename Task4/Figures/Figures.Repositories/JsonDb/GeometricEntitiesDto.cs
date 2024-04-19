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

        public Dictionary<int, GeometricEntity> AddEntities(GeometricEntitiesDto geometricEntitiesDto)
        {
            var entitiesMap = Enumerable.Empty<GeometricEntity>();
            {
                entitiesMap.Concat(geometricEntitiesDto.Points);
                entitiesMap.Concat(geometricEntitiesDto.LineSegments);
                entitiesMap.Concat(geometricEntitiesDto.Circles);
                entitiesMap.Concat(geometricEntitiesDto.Triangles);
                entitiesMap.Concat(geometricEntitiesDto.Rectangles);
                entitiesMap.Concat(geometricEntitiesDto.Rings);
            }

            var map = entitiesMap.ToDictionary(key => key.Id);

            return map;
        }
    }
}

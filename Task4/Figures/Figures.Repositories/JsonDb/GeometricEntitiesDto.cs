using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesDto
    {
        public List<PointDto> Points { get; set; } = new();
        public List<LineSegmentDto> LineSegments { get; set; } = new();
        public List<CircleDto> Circles { get; set; } = new();
        public List<RectangleDto> Rectangles { get; set; } = new();
        public List<TriangleDto> Triangles { get; set; } = new();
        public List<RingDto> Rings { get; set; } = new();

        public GeometricEntitiesDto(List<GeometricEntity> entities)
        {
            var entityMapper = new EntityMapper();
            foreach (var entity in entities)
            {
                switch (entity)
                {
                    case Point point:
                        Points.Add(entityMapper.ConvertToDto(point));
                        break;
                    case LineSegment lineSegment:
                        LineSegments.Add(entityMapper.ConvertToDto(lineSegment));
                        break;
                    case Circle circle:
                        Circles.Add(entityMapper.ConvertToDto(circle));
                        break;
                    case Rectangle rectangle:
                        Rectangles.Add(entityMapper.ConvertToDto(rectangle));
                        break;
                    case Triangle triangle:
                        Triangles.Add(entityMapper.ConvertToDto(triangle));
                        break;
                    case Ring ring:
                        Rings.Add(entityMapper.ConvertToDto(ring));
                        break;
                    default:
                        throw new ArgumentException("There is no such figure");
                }
            }
        }

        public GeometricEntitiesDto()
        {
        }
    }
}

using Figures.Model;
using Figures.Repositories.JsonDb.DtoModels;
using System;
using System.Collections.Generic;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesDto
    {
        private readonly EntityMapper _entityMapper = new();
        public List<PointDto> Points { get; set; } = new();
        public List<LineSegmentDto> LineSegments { get; set; } = new();
        public List<CircleDto> Circles { get; set; } = new();
        public List<RectangleDto> Rectangles { get; set; } = new();
        public List<TriangleDto> Triangles { get; set; } = new();
        public List<RingDto> Rings { get; set; } = new();

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
                        Points.Add(_entityMapper.ConvertToDto(point));
                        break;
                    case LineSegment lineSegment:
                        LineSegments.Add(_entityMapper.ConvertToDto(lineSegment));
                        break;
                    case Circle circle:
                        Circles.Add(_entityMapper.ConvertToDto(circle));
                        break;
                    case Rectangle rectangle:
                        Rectangles.Add(_entityMapper.ConvertToDto(rectangle));
                        break;
                    case Triangle triangle:
                        Triangles.Add(_entityMapper.ConvertToDto(triangle));
                        break;
                    case Ring ring:
                        Rings.Add(_entityMapper.ConvertToDto(ring));
                        break;
                    default:
                        throw new ArgumentException("There is no such figure");
                }
            }
        }

        public void AddEntities<T>(List<T> entityDto, Dictionary<int, GeometricEntity> entityMap) where T : GeometricEntityDto
        {
            foreach (var entity in entityDto)
            {
                switch (entity)
                {
                    case PointDto pointDto:
                        entityMap.Add(pointDto.Id, _entityMapper.ConvertFromDto(pointDto));
                        break;
                    case LineSegmentDto lineSegmentDto:
                        entityMap.Add(lineSegmentDto.Id, _entityMapper.ConvertFromDto(lineSegmentDto));
                        break;
                    case CircleDto circleDto:
                        entityMap.Add(circleDto.Id, _entityMapper.ConvertFromDto(circleDto));
                        break;
                    case RectangleDto rectangleDto:
                        entityMap.Add(rectangleDto.Id, _entityMapper.ConvertFromDto(rectangleDto));
                        break;
                    case TriangleDto triangleDto:
                        entityMap.Add(triangleDto.Id, _entityMapper.ConvertFromDto(triangleDto));
                        break;
                    case RingDto ringDto:
                        entityMap.Add(ringDto.Id, _entityMapper.ConvertFromDto(ringDto));
                        break;
                    default:
                        throw new ArgumentException("There is no such figure");
                }
            }
        }
    }
}

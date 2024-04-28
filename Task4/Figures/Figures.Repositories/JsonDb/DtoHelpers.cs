using Figures.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Repositories.JsonDb
{
    public static class DtoHelpers
    {
        public static GeometricEntitiesDto ConvertToDto(List<GeometricEntity> entities)
        {
            var geometricEntitiesDto = new GeometricEntitiesDto();

            foreach (var entity in entities)
            {
                switch (entity)
                {
                    case Point point:
                        geometricEntitiesDto.Points.Add(point);
                        break;
                    case LineSegment lineSegment:
                        geometricEntitiesDto.LineSegments.Add(lineSegment);
                        break;
                    case Circle circle:
                        geometricEntitiesDto.Circles.Add(circle);
                        break;
                    case Rectangle rectangle:
                        geometricEntitiesDto.Rectangles.Add(rectangle);
                        break;
                    case Triangle triangle:
                        geometricEntitiesDto.Triangles.Add(triangle);
                        break;
                    case Ring ring:
                        geometricEntitiesDto.Rings.Add(ring);
                        break;
                    default:
                        throw new ArgumentException("There is no such figure");
                }
            }

            return geometricEntitiesDto;
        }

        public static Dictionary<int, GeometricEntity> ConvertFromDto(GeometricEntitiesDto geometricEntitiesDto)
        {
            return Enumerable.Empty<GeometricEntity>()
                .Concat(geometricEntitiesDto.Points)
                .Concat(geometricEntitiesDto.LineSegments)
                .Concat(geometricEntitiesDto.Circles)
                .Concat(geometricEntitiesDto.Triangles)
                .Concat(geometricEntitiesDto.Rectangles)
                .Concat(geometricEntitiesDto.Rings)
                .ToDictionary(key => key.Id);
        }
    }
}

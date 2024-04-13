using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesReader : IGeometricEntitiesReader
    {
        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            WriteIndented = true,
        };

        private readonly ISourceIO _sourceIO;

        public GeometricEntitiesReader(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public GeometricEntitiesContext ReadFile()
        {
            var jsonStr = _sourceIO.ReadAllText();

            if (jsonStr == string.Empty)
            {
                return new GeometricEntitiesContext();
            }

            var geometricEntitiesDto = JsonSerializer.Deserialize<GeometricEntitiesDto> (jsonStr, JsonOptions);
            var entityMap = new Dictionary<int, GeometricEntity>();
            var context = new GeometricEntitiesContext(entityMap);
            AddEntities<PointDto>(geometricEntitiesDto.Points, entityMap);
            AddEntities<CircleDto>(geometricEntitiesDto.Circles, entityMap);
            AddEntities<LineSegmentDto>(geometricEntitiesDto.LineSegments, entityMap);
            AddEntities<TriangleDto>(geometricEntitiesDto.Triangles, entityMap);
            AddEntities<RectangleDto>(geometricEntitiesDto.Rectangles, entityMap);
            AddEntities<RingDto>(geometricEntitiesDto.Rings, entityMap);
            context.IdGenerator.Reload(entityMap);
            return context;
        }

        private void AddEntities<T>(List<T> entityDto, Dictionary<int, GeometricEntity> entityMap) where T : GeometricEntityDto
        {
            var entityMapper = new EntityMapper();

            foreach (var entity in entityDto)
            {
                switch (entity)
                {
                    case PointDto pointDto:
                        entityMap.Add(pointDto.Id, entityMapper.ConvertFromDto(pointDto));
                        break;
                    case LineSegmentDto lineSegmentDto:
                        entityMap.Add(lineSegmentDto.Id, entityMapper.ConvertFromDto(lineSegmentDto));
                        break;
                    case CircleDto circleDto:
                        entityMap.Add(circleDto.Id, entityMapper.ConvertFromDto(circleDto));
                        break;
                    case RectangleDto rectangleDto:
                        entityMap.Add(rectangleDto.Id, entityMapper.ConvertFromDto(rectangleDto));
                        break;
                    case TriangleDto triangleDto:
                        entityMap.Add(triangleDto.Id, entityMapper.ConvertFromDto(triangleDto));
                        break;
                    case RingDto ringDto:
                        entityMap.Add(ringDto.Id, entityMapper.ConvertFromDto(ringDto));
                        break;
                    default:
                        throw new ArgumentException("There is no such figure");
                }
            }
        }
    }
}
using Figures.Model;
using Figures.Repositories.Interface;
using System.Collections.Generic;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesReader : IGeometricEntitiesReader
    {
        private readonly GeometricEntitiesDto _geometricEntitiesDto = new();
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

            var geometricEntitiesDto = JsonSerializer.Deserialize<GeometricEntitiesDto> (jsonStr, JsonSettings.JsonOptions);
            var entityMap = new Dictionary<int, GeometricEntity>();
            _geometricEntitiesDto.AddEntities(geometricEntitiesDto.Points, entityMap);
            _geometricEntitiesDto.AddEntities(geometricEntitiesDto.Circles, entityMap);
            _geometricEntitiesDto.AddEntities(geometricEntitiesDto.LineSegments, entityMap);
            _geometricEntitiesDto.AddEntities(geometricEntitiesDto.Triangles, entityMap);
            _geometricEntitiesDto.AddEntities(geometricEntitiesDto.Rectangles, entityMap);
            _geometricEntitiesDto.AddEntities(geometricEntitiesDto.Rings, entityMap);
            return new GeometricEntitiesContext(entityMap);
        }
    }
}
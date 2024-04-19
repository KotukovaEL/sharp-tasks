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
            var entityMap = _geometricEntitiesDto.AddEntities(geometricEntitiesDto);
            return new GeometricEntitiesContext(entityMap);
        }
    }
}
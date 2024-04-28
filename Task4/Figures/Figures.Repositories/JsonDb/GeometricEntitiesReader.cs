using Figures.Repositories.Interface;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesReader : IGeometricEntitiesReader
    {
        private readonly ISourceIO _sourceIO;

        public GeometricEntitiesReader(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public GeometricEntitiesContext ReadFile()
        {
            var jsonStr = _sourceIO.ReadAllText();

            if (string.IsNullOrWhiteSpace(jsonStr))
            {
                return new GeometricEntitiesContext();
            }

            var geometricEntitiesDto = JsonSerializer.Deserialize<GeometricEntitiesDto> (jsonStr, JsonSettings.JsonOptions);
            var entityMap = DtoHelpers.ConvertFromDto(geometricEntitiesDto);
            return new GeometricEntitiesContext(entityMap);
        }
    }
}
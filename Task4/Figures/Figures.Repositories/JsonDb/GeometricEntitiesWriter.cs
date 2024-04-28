using Figures.Repositories.Interface;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesWriter : IGeometricEntitiesWriter
    {
        private readonly ISourceIO _sourceIO;

        public GeometricEntitiesWriter(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public void SaveChanges(GeometricEntitiesContext context)
        {
            var geometricEntitiesDto = DtoHelpers.ConvertToDto(context.List());
            var json = JsonSerializer.Serialize(geometricEntitiesDto, JsonSettings.JsonOptions);
            _sourceIO.WriteAllText(json);
        }
    }
}

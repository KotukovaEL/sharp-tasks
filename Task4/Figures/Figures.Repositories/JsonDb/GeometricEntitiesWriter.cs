using Figures.Model;
using Figures.Repositories.Interface;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesWriter : IGeometricEntitiesWriter
    {
        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            WriteIndented = true,
        };

        private readonly ISourceIO _sourceIO;

        public GeometricEntitiesWriter(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public void SaveChanges(GeometricEntitiesContext context)
        {
            var geometricEntitiesDto = new GeometricEntitiesDto(context.List());
            var json = JsonSerializer.Serialize(geometricEntitiesDto, JsonOptions);
            _sourceIO.WriteAllText(json);
        }
    }
}

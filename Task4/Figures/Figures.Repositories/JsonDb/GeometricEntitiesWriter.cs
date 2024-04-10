using Figures.Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class GeometricEntitiesWriter
    {
        private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            WriteIndented = true,
        };

        public void Save()
        {
            var entitiesList = new List<GeometricEntity>(){};
            var json = JsonSerializer.Serialize(entitiesList, JsonOptions);
            var file = File.CreateText("entities.json");
            file.WriteLine(json);
            file.Close();
        }
    }
}

using Figures.Model;
using Figures.Repositories.Interface;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
{
    public class UsersWriter : IUsersWriter
    {
        private readonly ISourceIO _sourceIO;

        public UsersWriter(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public void SaveChanges(Dictionary<string, User> entitiesMap)
        {
            var json = JsonSerializer.Serialize(entitiesMap, JsonSettings.JsonOptions);
            _sourceIO.WriteAllText(json);
        }
    }
}

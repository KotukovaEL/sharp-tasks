using Figures.Common.Interfaces;
using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Figures.Repositories
{
    public class UsersTxtDbContext : ITxtDbContext<string, User>
    {
        private readonly string _filePath;
        public Dictionary<string, User> EntitiesMap { get; } = new();
        public UsersTxtDbContext(string filePath)
        {
            _filePath = filePath;
            ReadFile();
        }

        public User GetByKey(string name)
        {
            if (!EntitiesMap.TryGetValue(name, out User user))
            {
                throw new ArgumentException($"User {name} was not found");
            }

            return user;
        }

        public void Add(User user)
        {
            EntitiesMap.TryAdd(user.Name, user);
        }

        public void ReadFile()
        {
            var lines = File.ReadAllLines(_filePath);
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var (key, value) = TxtDbHelpers.ParseDbRecord(line);
                    map.Add(key.Trim(), value.Trim());
                    continue;
                }

                var name = TxtDbHelpers.GetFieldValue(map, "Name");
                var entityIdStr = TxtDbHelpers.GetFieldValue(map, "EntityList");
                map.Clear();
                var user = new User(name);

                if (entityIdStr != string.Empty)
                {
                    var entityList = entityIdStr.Split(",").Select(int.Parse).ToList();
                    user.EntityIdList.AddRange(entityList);
                }

                EntitiesMap.Add(name, user);
            }
        }

        public void SaveChanges()
        {
            using var fs = new FileStream(_filePath, FileMode.Create);
            using var stream = new StreamWriter(fs);

            foreach (var user in EntitiesMap.Values)
            {
                stream.WriteLine($" Name: {user.Name}");
                stream.WriteLine($" EntityList: {string.Join(',', user.EntityIdList)}");
                stream.WriteLine();
            }
        }
    }
}

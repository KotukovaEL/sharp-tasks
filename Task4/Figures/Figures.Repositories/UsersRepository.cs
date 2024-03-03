using Figures.Common.Interfaces;
using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Figures.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly Dictionary<string, User> _userMap = new();
        private readonly string _filePath;

        public UsersRepository(string filePath)
        {
            _filePath = filePath;
            ReadFile();
        }

        public void TryAdd(string name)
        {
            _userMap.TryAdd(name, new User(name));
        }

        public User GetUser(string name)
        {
            if (!_userMap.TryGetValue(name, out User user))
            {
                throw new ArgumentException($"User {name} was not found");
            }

            return user;
        }
        public void SaveChanges()
        {
            using var fs = new FileStream(_filePath, FileMode.Create);
            using var stream = new StreamWriter(fs);

            foreach (var user in _userMap.Values)
            {
                stream.WriteLine($" Name: {user.Name}");
                stream.WriteLine($" EntityList: {string.Join(',', user.EntityIdList)}");
                stream.WriteLine();
            }
        }

        private void ReadFile()
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

                _userMap.Add(name, user);
            }
        }
    }
}

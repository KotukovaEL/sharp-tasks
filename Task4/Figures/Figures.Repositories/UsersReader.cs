using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figures.Repositories
{
    public class UsersReader : IUsersReader
    {
        private readonly ISourceIO _sourceIO;

        public UsersReader(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public Dictionary<string, User> ReadFile()
        {
            var usersMap = new Dictionary<string, User>();
            var lines = _sourceIO.ReadAllLines();
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var str = line.Trim();
                if (TxtDbHelpers.TryParseDbRecord(str, out var key, out var value))
                {
                    map.Add(key, value);
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

                usersMap.Add(name, user);
            }

            return usersMap;
        }
    }
}

using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Figures.Repositories.JsonDb
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
            var jsonStr = _sourceIO.ReadAllText();

            if (jsonStr == string.Empty)
            {
                return usersMap;
            }

            var json =  JsonSerializer.Deserialize<Dictionary<string, User>>(jsonStr);
            
            foreach(var user in json)
            {
                usersMap.Add(user.Key, user.Value);
            }

            return usersMap;
        }
    }
}

using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories
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
            using var stream = _sourceIO.CreateWriter();

            foreach (var user in entitiesMap)
            {
                stream.WriteLine($" Name: {user.Value.Name}");
                stream.WriteLine($" EntityList: {string.Join(',', user.Value.EntityIdList)}");
                stream.WriteLine();
            }
        }
    }
}

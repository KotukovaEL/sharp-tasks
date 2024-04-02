using Figures.Common.Interfaces;
using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace Figures.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IUsersWriter _usersWriter;
        private readonly Dictionary<string, User> _usersMap;

        public UsersRepository(IUsersWriter usersWriter, IUsersReader usersReader)
        {
            _usersWriter = usersWriter;
            _usersMap = usersReader.ReadFile();
        }

        public void TryAdd(string name)
        {
            _usersMap.TryAdd(name, new User(name));
            _usersWriter.SaveChanges(_usersMap);
        }

        public void AddFigure(string name, int figureId)
        {
            var user = GetUser(name);
            user.EntityIdList.Add(figureId);
            _usersWriter.SaveChanges(_usersMap);
        }

        public User GetUser(string name)
        {
            return GetByKey(name);
        }

        public User GetByKey(string name)
        {
            if (!_usersMap.TryGetValue(name, out User user))
            {
                throw new ArgumentException($"User {name} was not found");
            }

            return user;
        }
    }
}

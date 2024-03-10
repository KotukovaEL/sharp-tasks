using Figures.Common.Interfaces;
using Figures.Model;
using System;

namespace Figures.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ITxtDbContext<string, User> _usersContext;

        public UsersRepository(ITxtDbContext<string, User> usersContext)
        {
            _usersContext = usersContext;
        }

        public void TryAdd(string name)
        {
            _usersContext.EntitiesMap.TryAdd(name, new User(name));
            _usersContext.SaveChanges();
        }

        public User GetUser(string name)
        {
            return _usersContext.GetByKey(name);
        }
    }
}

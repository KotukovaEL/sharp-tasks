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
            _usersContext.Add(new User(name));
            _usersContext.SaveChanges();
        }

        public void AddFigure(string name, int idFigure)
        {
            var user = GetUser(name);
            user.EntityIdList.Add(idFigure);
            _usersContext.SaveChanges();
        }

        public User GetUser(string name)
        {
            return _usersContext.GetByKey(name);
        }
    }
}

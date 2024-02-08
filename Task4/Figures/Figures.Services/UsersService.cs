using Figures.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Figures.Services
{
    public class UsersService
    {
        private readonly List<User> _users;

        public UsersService()
        {
            _users = new List<User>();
        }
        public void AddFigures(string name, GeometricEntity geometricEntity)
        {
            var user = _users.SingleOrDefault(u => u.Name == name);
            user.GeometricEntities.Add(geometricEntity);
        }
        
        public List<GeometricEntity> ListFigures(string name)
        {
            var user = _users.SingleOrDefault(u => u.Name == name);
            return new List<GeometricEntity>(user.GeometricEntities);
        }

        public void ClearFigures(string name)
        {
            var user = _users.SingleOrDefault(u => u.Name == name);
            user.GeometricEntities.Clear();
        }

        public void Authorize(string name)
        {
            var user = _users.SingleOrDefault(u => u.Name == name);

            if (user is null)
            {
                _users.Add(new User(name));
            }
        }
    }
}

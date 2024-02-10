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
        private readonly Dictionary<string, User> _userMap;

        public UsersService()
        {
            _userMap = new Dictionary<string, User>();
        }
        public void AddFigures(string name, GeometricEntity geometricEntity)
        {
            var user = GetUser(name);
            user.GeometricEntities.Add(geometricEntity);
        }
        
        public List<GeometricEntity> ListFigures(string name)
        {
            var user = GetUser(name);
            return new List<GeometricEntity>(user.GeometricEntities);
        }

        public void ClearFigures(string name)
        {
            var user = GetUser(name);
            user.GeometricEntities.Clear();
        }

        public void Authorize(string name)
        {
            _userMap.TryAdd(name, new User(name));
        }

        private User GetUser(string name)
        {
            if (!_userMap.TryGetValue(name, out User user))
            {
                throw new ArgumentException($"User {name} was not found");
            }

            return user;
        }
    }
}

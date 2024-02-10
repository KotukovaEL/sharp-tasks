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
        private readonly Dictionary<string, List<GeometricEntity>> _dictionary;

        public UsersService()
        {
            _dictionary = new Dictionary<string, List<GeometricEntity>>();
        }
        public void AddFigures(string name, GeometricEntity geometricEntity)
        {
            var user = _dictionary.SingleOrDefault(u => u.Key == name);
            user.Value.Add(geometricEntity);
        }
        
        public List<GeometricEntity> ListFigures(string name)
        {
            var user = _dictionary.SingleOrDefault(u => u.Key == name);
            return new List<GeometricEntity>(user.Value);
        }

        public void ClearFigures(string name)
        {
            var user = _dictionary.SingleOrDefault(u => u.Key == name);
            user.Value.Clear();
        }

        public void Authorize(string name)
        {
            var user = _dictionary.SingleOrDefault(u => u.Key == name);

            if (user.Key is null)
            {
                _dictionary.Add(name, new List<GeometricEntity>());
            }
        }
    }
}

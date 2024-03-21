using Figures.Common.Interfaces;
using Figures.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Repositories
{
    public class IdGenerator 
    {
        private readonly HashSet<int> _ids = new();

        public void Reload(Dictionary<int, GeometricEntity> entity)
        {
            _ids.Clear();

            foreach (var id in entity.Keys)
            {
                _ids.Add(id);
            }
        }

        public void Add(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id should be positive.");
            }

            if (!_ids.Add(id))
            {
                throw new ArgumentException("There is already a figure with this id.");
            }

            _ids.Add(id);
        }

        public int Generate()
        {
            int id = _ids.Count == 0 ? 1 : _ids.Max();

            if (_ids.Count != 0)
            {
                id = _ids.Max() + 1;
            }

            _ids.Add(id);
            return id;
        }
    }
}

using Figures.Common.Interfaces;
using Figures.Model;
using System.Collections.Generic;
using System.Linq;

namespace Figures.Repositories
{
    public class IdGenerator 
    {
        private readonly HashSet<int> _ids = new();

        public void Reload(Dictionary<int, GeometricEntity> entity)
        {
            var id = entity.Keys.Select(x => x).ToList();

            foreach (var key in id)
            {
                _ids.Add(key);
            }
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

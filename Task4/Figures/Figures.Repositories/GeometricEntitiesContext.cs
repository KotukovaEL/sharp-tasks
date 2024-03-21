using Figures.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figures.Repositories
{
    public class GeometricEntitiesContext
    {
        public IdGenerator IdGenerator { get; } = new();
        private readonly Dictionary<int, GeometricEntity> _entitiesMap;

        public GeometricEntitiesContext()
        {
            _entitiesMap = new();
        }

        public GeometricEntitiesContext(Dictionary<int, GeometricEntity> entitiesMap)
        {
            _entitiesMap = entitiesMap;
            IdGenerator.Reload(_entitiesMap);
        }

        public GeometricEntity GetByKey(int id)
        {
            if (!_entitiesMap.TryGetValue(id, out var entity))
            {
                throw new ArgumentException($"Entity with id '{id}' was not found.");
            }

            return entity;
        }

        public List<GeometricEntity> List()
        {
            return _entitiesMap.Select(x => x.Value).OrderBy(x => x.Id).ToList();
        }

        public void Add(GeometricEntity entity)
        {
            if (entity.Id == 0)
            {
                entity.Id = IdGenerator.Generate();
            }
            else
            {
                IdGenerator.Add(entity.Id);
            }
            
            _entitiesMap.Add(entity.Id, entity);
        }

        public void Remove(int id)
        {
            _entitiesMap.Remove(id);
        }
    }
}

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
        public Dictionary<int, GeometricEntity> EntitiesMap { get; } = new();

        public GeometricEntity GetByKey(int id)
        {
            if (!EntitiesMap.TryGetValue(id, out var entity))
            {
                throw new ArgumentException($"Entity with id '{id}' was not found.");
            }

            return entity;
        }

        public List<GeometricEntity> List()
        {
            return EntitiesMap.Select(x => x.Value).OrderBy(x => x.Id).ToList();
        }
        public void Add(GeometricEntity entity)
        {
            entity.Id = IdGenerator.Generate();
            EntitiesMap.Add(entity.Id, entity);
        }
    }
}

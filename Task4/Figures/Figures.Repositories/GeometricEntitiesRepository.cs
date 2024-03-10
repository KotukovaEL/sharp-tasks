using Figures.Common.Interfaces;
using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Figures.Repositories
{
    public class GeometricEntitiesRepository : IGeometricEntitiesRepository
    {
        private readonly ITxtDbContext<int, GeometricEntity> _entitiesContext;

        public GeometricEntitiesRepository(ITxtDbContext<int, GeometricEntity> entitiesContext)
        {
            _entitiesContext = entitiesContext;
        }

        public List<GeometricEntity> List()
        {
            return _entitiesContext.EntitiesMap.Select(x => x.Value).OrderBy(x => x.Id).ToList();
        }

        public GeometricEntity GetEntityById(int id)
        {
            return _entitiesContext.GetByKey(id);
        }

        public void Add(GeometricEntity entity)
        {
            entity.Id = _entitiesContext.IdGenerator.Generate();
            _entitiesContext.EntitiesMap.Add(entity.Id, entity);
            _entitiesContext.SaveChanges();
        }

        public void DeleteFiguresByIds(List<int> list)
        {
            foreach (int id in list)
            {
                _entitiesContext.EntitiesMap.Remove(id);
            }

            _entitiesContext.SaveChanges();
        }
    }
}

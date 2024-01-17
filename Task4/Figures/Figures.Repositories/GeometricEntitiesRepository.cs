using Figures.Model;
using System;
using System.Collections.Generic;

namespace Figures.Repositories
{
    public class GeometricEntitiesRepository
    {
        private readonly List<GeometricEntity> _geometricEntities;

        public GeometricEntitiesRepository()
        {
            _geometricEntities = new List<GeometricEntity>();
        }

        public void Add(GeometricEntity geometricEntity)
        {
            _geometricEntities.Add(geometricEntity);
        }

        public List<GeometricEntity> List()
        {
            return new List<GeometricEntity>(_geometricEntities);
        }

        public void DeleteAll()
        {
            _geometricEntities.Clear();
        }
    }
}

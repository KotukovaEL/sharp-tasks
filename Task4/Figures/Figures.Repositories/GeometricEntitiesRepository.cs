using Figures.Common.Interfaces;
using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Figures.Repositories
{
    public class GeometricEntitiesRepository : IGeometricEntitiesRepository
    {
        private readonly GeometricEntitiesContext _context;
        private readonly IGeometricEntitiesWriter _writer;

        public GeometricEntitiesRepository(IGeometricEntitiesWriter writer, IGeometricEntitiesReader reader)
        {
            _context = reader.ReadFile();
            _writer = writer;
        }

        public List<GeometricEntity> List()
        {
            return _context.List();
        }

        public void Add(GeometricEntity entity)
        {
            _context.Add(entity);
            _writer.SaveChanges(_context);
        }

        public GeometricEntity GetEntityById(int id)
        {
            return _context.GetByKey(id);
        }

        public void DeleteFiguresByIds(List<int> idList)
        {
            foreach (int id in idList)
            {
                _context.Remove(id);
            }

            _writer.SaveChanges(_context);
        }
    }
}

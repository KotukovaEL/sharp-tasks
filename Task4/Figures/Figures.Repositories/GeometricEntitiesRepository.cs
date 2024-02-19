using Figures.Model;
using Figures.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace Figures.Repositories
{
    public class GeometricEntitiesRepository : IGeometricEntitiesRepository
    {
        private readonly TxtDbContext _context;

        public GeometricEntitiesRepository(TxtDbContext context)
        {
            _context = context;
        }

        public void Add(GeometricEntity geometricEntity)
        {
            _context.Add(geometricEntity);
            _context.SaveChanges();
        }

        public List<GeometricEntity> List()
        {
            return _context.List();
        }

        public void DeleteAll()
        {
            _context.DeleteAll();
            _context.SaveChanges();
        }
    }
}

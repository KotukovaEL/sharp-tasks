using Figures.Model;
using Figures.Services;
using System.Collections.Generic;
using System.Diagnostics;

namespace Figures.Repositories
{
    public class GeometricEntitiesRepository : IGeometricEntitiesRepository
    {
        private readonly TxtDbContext _context;

        public GeometricEntitiesRepository()
        {
            _context = new TxtDbContext();
        }

        public void Add(GeometricEntity geometricEntity)
        {
            _context.Points.Add(geometricEntity as Point);
            _context.SaveChange();
        }

        public List<GeometricEntity> List()
        {
            return new List<GeometricEntity>(_context.Points);
        }

        public void DeleteAll()
        {
            _context.Points.Clear();
        }

        public void ReadFile()
        {
            _context.ReadFile();
        }
    }
}

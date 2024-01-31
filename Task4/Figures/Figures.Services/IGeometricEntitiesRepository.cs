using Figures.Model;
using System.Collections.Generic;

namespace Figures.Services
{
    public interface IGeometricEntitiesRepository
    {
        void Add(GeometricEntity geometricEntity);
        List<GeometricEntity> List();
        void DeleteAll();
    }
}

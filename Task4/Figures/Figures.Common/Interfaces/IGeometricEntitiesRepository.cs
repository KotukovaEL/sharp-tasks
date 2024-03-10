using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Common.Interfaces
{
    public interface IGeometricEntitiesRepository
    {
        List<GeometricEntity> List();
        void Add(GeometricEntity entity);
        void DeleteFiguresByIds(List<int> list);
        GeometricEntity GetEntityById(int id);
    }
}

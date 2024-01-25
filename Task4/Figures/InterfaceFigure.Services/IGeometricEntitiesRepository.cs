using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceFigure.Services
{
    public interface IGeometricEntitiesRepository
    {
        void Add(GeometricEntity geometricEntity);
        List<GeometricEntity> List();
        void DeleteAll();
    }
}

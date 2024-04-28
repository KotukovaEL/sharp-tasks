using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Interface
{
    public interface IGeometricEntitiesWriter
    {
        void SaveChanges(GeometricEntitiesContext context);
    }
}

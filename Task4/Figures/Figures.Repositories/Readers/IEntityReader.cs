using Figures.Model;
using Figures.Repositories.Writers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public interface IEntityReader<out T> where T : GeometricEntity
    {
        T Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context);
    }
}

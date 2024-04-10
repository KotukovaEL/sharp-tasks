using Figures.Model;
using System.Collections.Generic;

namespace Figures.Repositories.TxtDb.Readers
{
    public interface IEntityReader<out T> where T : GeometricEntity
    {
        T Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context);
    }
}

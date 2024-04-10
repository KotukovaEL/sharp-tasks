using Figures.Model;
using System.IO;

namespace Figures.Repositories.TxtDb.Writers
{
    public interface IEntityWriter<T> where T : GeometricEntity
    {
        void Save(TextWriter writer, T entity, IdGenerator idGenerator);
    }
}

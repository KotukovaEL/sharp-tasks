using Figures.Model;
using System.IO;

namespace Figures.Repositories.TxtDb.Writers
{
    public class EntityWriter<T> : IEntityWriter<GeometricEntity> where T : GeometricEntity
    {
        private readonly IEntityWriter<T> _writer;

        public EntityWriter(IEntityWriter<T> writer)
        {
            _writer = writer;
        }

        public void Save(TextWriter writer, GeometricEntity entity, IdGenerator idGenerator)
        {
            _writer.Save(writer, (T)entity, idGenerator);
        }
    }
}

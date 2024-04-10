using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.TxtDb.Readers
{
    public class EntityReader<T> : IEntityReader<GeometricEntity> where T : GeometricEntity
    {
        private readonly IEntityReader<T> _reader;

        public EntityReader(IEntityReader<T> reader)
        {
            _reader = reader;
        }

        public GeometricEntity Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            return _reader.Read(fieldsMap, context);
        }
    }
}

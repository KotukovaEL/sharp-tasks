using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class GeometricEntitiesWriter : IGeometricEntitiesWriter
    {
        private readonly ISourceIO _sourceIO;
        private Dictionary<string, IEntityWriter<GeometricEntity>> _writersMap;

        public GeometricEntitiesWriter(ISourceIO sourceIO, Dictionary<string, IEntityWriter<GeometricEntity>> writersMap)
        {
            _sourceIO = sourceIO;
            _writersMap = writersMap;
        }

        public void SaveChanges(GeometricEntitiesContext context)
        {
            using var stream = _sourceIO.CreateWriter();

            foreach (var entity in context.List())
            {
                string entityType = entity.GetType().Name;

                if (!_writersMap.TryGetValue(entityType, out var writer))
                {
                    throw new ArgumentException($"Entity writer for type {entityType} was not found.");
                }

                writer.Save(stream, entity, context.IdGenerator);
            }
        }
    }
}

using Figures.Model;
using Figures.Repositories.Interface;
using Figures.Repositories.Readers;
using System;
using System.Collections.Generic;

namespace Figures.Repositories
{
    public class GeometricEntitiesReader : IGeometricEntitiesReader
    {
        private readonly ISourceIO _sourceIO;
        private Dictionary<string, IEntityReader<GeometricEntity>> _readersMap;
        public GeometricEntitiesReader(ISourceIO sourceIO, Dictionary<string, IEntityReader<GeometricEntity>> readersMap)
        {
            _sourceIO = sourceIO;
            _readersMap = readersMap;
        }

        public GeometricEntitiesContext ReadFile()
        {
            var context = new GeometricEntitiesContext();
            var lines = _sourceIO.ReadAllLines();
            var fieldsMap = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var str = line.Trim();

                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }

                if (TxtDbHelpers.TryParseDbRecord(str, out var key, out var value))
                {
                    fieldsMap.Add(key, value);
                    continue;
                }

                if (!_readersMap.TryGetValue(str, out var reader))
                {
                    throw new ArgumentException($"Entity reader for type {str} was not found.");
                }

                var entity = reader.Read(fieldsMap, context);
                context.Add(entity);
                fieldsMap.Clear();
                continue;
            }

            return context;
        }
    }
}

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
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var str = line.Trim();

                if (IsNumberContains(str))
                {
                    var parseStr = TxtDbHelpers.ParseDbRecord(str);
                    map.Add(parseStr.key, parseStr.value);
                    continue;
                }

                if (string.IsNullOrWhiteSpace(str))
                {
                    continue;
                }

                if (!_readersMap.TryGetValue(str, out var reader))
                {
                    throw new ArgumentException($"Entity reader for type {str} was not found.");
                }

                var entity = reader.Read(map, context);

                if (entity is not null)
                {
                    context.Add(entity);
                    map.Clear();
                    continue;
                }
            }

            return context;
        }
        private bool IsNumberContains(string str)
        {
            foreach (char number in str)
            {
                if (Char.IsNumber(number))
                {
                    return true;
                }                    
            }

            return false;
        }
    }
}

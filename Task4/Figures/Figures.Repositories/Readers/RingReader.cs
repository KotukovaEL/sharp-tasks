using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class RingReader : IEntityReader<Ring>
    {
        public Ring Read(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idPoint = int.Parse(TxtDbHelpers.GetFieldValue(map, "Center"));
            var center = (Point)context.GetByKey(idPoint);
            var longRadius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Long radius"));
            var shortRadius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Short radius"));
            context.Remove(idPoint);
            var ring = new Ring(center, longRadius, shortRadius);
            ring.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return ring;
        }
    }
}

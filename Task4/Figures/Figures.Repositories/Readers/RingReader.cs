using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class RingReader : IEntityReader<Ring>
    {
        public Ring Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            var pointId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Center"));
            var center = (Point)context.GetByKey(pointId);
            var longRadius = double.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Long radius"));
            var shortRadius = double.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Short radius"));
            context.Remove(pointId);
            return new Ring(center, longRadius, shortRadius)
            {
                Id = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Id"))
            };
        }
    }
}

using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.TxtDb.Readers
{
    public class CircleReader : IEntityReader<Circle>
    {
        public Circle Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            var pointId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Center"));
            var center = (Point)context.GetByKey(pointId);
            var radius = double.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Radius"));
            context.Remove(pointId);
            return new Circle()
            {
                Center = center,
                Radius = radius,
                Id = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Id"))
            };
        }
    }
}

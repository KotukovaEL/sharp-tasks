using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class CircleReader : IEntityReader<Circle>
    {
        public Circle Read(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idPoint = int.Parse(TxtDbHelpers.GetFieldValue(map, "Center"));
            var center = (Point)context.GetByKey(idPoint);
            var radius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Radius"));
            context.Remove(idPoint);
            var circle = new Circle(center, radius);
            circle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return circle;
        }
    }
}

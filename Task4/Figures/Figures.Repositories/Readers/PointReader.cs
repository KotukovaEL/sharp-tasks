using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class PointReader : IEntityReader<Point>
    {
        public Point Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            var x = double.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "X"));
            var y = double.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Y"));
            return new Point(x, y)
            {
                Id = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Id"))
            };
        }
    }
}

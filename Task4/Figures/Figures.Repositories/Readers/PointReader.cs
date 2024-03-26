using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class PointReader : IEntityReader<Point>
    {
        public Point Read(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var x = double.Parse(TxtDbHelpers.GetFieldValue(map, "X"));
            var y = double.Parse(TxtDbHelpers.GetFieldValue(map, "Y"));
            var point = new Point(x, y);
            point.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return point;
        }
    }
}

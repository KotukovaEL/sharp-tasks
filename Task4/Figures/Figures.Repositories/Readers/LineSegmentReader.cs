using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class LineSegmentReader : IEntityReader<LineSegment>
    {
        public LineSegment Read(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idA = int.Parse(TxtDbHelpers.GetFieldValue(map, "A"));
            var idB = int.Parse(TxtDbHelpers.GetFieldValue(map, "B"));
            var pointA = (Point)context.GetByKey(idA);
            var pointB = (Point)context.GetByKey(idB);
            context.Remove(idA);
            context.Remove(idB);
            var lineSegment = new LineSegment(pointA, pointB);
            lineSegment.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return lineSegment;
        }
    }
}

using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.TxtDb.Readers
{
    public class LineSegmentReader : IEntityReader<LineSegment>
    {
        public LineSegment Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            var aId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "A"));
            var bId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "B"));
            var pointA = (Point)context.GetByKey(aId);
            var pointB = (Point)context.GetByKey(bId);
            context.Remove(aId);
            context.Remove(bId);
            return new LineSegment(pointA, pointB)
            {
                Id = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Id"))
            };
        }
    }
}

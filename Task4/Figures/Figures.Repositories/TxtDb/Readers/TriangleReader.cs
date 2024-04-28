using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.TxtDb.Readers
{
    public class TriangleReader : IEntityReader<Triangle>
    {
        public Triangle Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            var aId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "A"));
            var bId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "B"));
            var cId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "C"));
            var pointA = (Point)context.GetByKey(aId);
            var pointB = (Point)context.GetByKey(bId);
            var pointC = (Point)context.GetByKey(cId);
            context.Remove(aId);
            context.Remove(bId);
            context.Remove(cId);
            return new Triangle()
            {
                A = pointA,
                B = pointB,
                C = pointC,
                Id = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Id"))
            };
        }
    }
}

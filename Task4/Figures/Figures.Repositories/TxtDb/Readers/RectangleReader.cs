using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.TxtDb.Readers
{
    public class RectangleReader : IEntityReader<Rectangle>
    {
        public Rectangle Read(Dictionary<string, string> fieldsMap, GeometricEntitiesContext context)
        {
            var aId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "A"));
            var bId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "B"));
            var cId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "C"));
            var dId = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "D"));
            var pointA = (Point)context.GetByKey(aId);
            var pointB = (Point)context.GetByKey(bId);
            var pointC = (Point)context.GetByKey(cId);
            var pointD = (Point)context.GetByKey(dId);
            context.Remove(aId);
            context.Remove(bId);
            context.Remove(cId);
            context.Remove(dId);
            return new Rectangle()
            {
                A = pointA,
                B = pointB,
                C = pointC,
                D = pointD,
                Id = int.Parse(TxtDbHelpers.GetFieldValue(fieldsMap, "Id"))
            };
        }
    }
}

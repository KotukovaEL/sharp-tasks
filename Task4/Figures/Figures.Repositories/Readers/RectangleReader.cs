using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class RectangleReader : IEntityReader<Rectangle>
    {
        public Rectangle Read(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idA = int.Parse(TxtDbHelpers.GetFieldValue(map, "A"));
            var idB = int.Parse(TxtDbHelpers.GetFieldValue(map, "B"));
            var idC = int.Parse(TxtDbHelpers.GetFieldValue(map, "C"));
            var idD = int.Parse(TxtDbHelpers.GetFieldValue(map, "D"));
            var pointA = (Point)context.GetByKey(idA);
            var pointB = (Point)context.GetByKey(idB);
            var pointC = (Point)context.GetByKey(idC);
            var pointD = (Point)context.GetByKey(idD);
            context.Remove(idA);
            context.Remove(idB);
            context.Remove(idC);
            context.Remove(idD);
            var rectangle = new Rectangle(pointA, pointB, pointC, pointD);
            rectangle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return rectangle;
        }
    }
}

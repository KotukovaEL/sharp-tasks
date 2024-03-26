using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Repositories.Readers
{
    public class TriangleReader : IEntityReader<Triangle>
    {
        public Triangle Read(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idA = int.Parse(TxtDbHelpers.GetFieldValue(map, "A"));
            var idB = int.Parse(TxtDbHelpers.GetFieldValue(map, "B"));
            var idC = int.Parse(TxtDbHelpers.GetFieldValue(map, "C"));
            var pointA = (Point)context.GetByKey(idA);
            var pointB = (Point)context.GetByKey(idB);
            var pointC = (Point)context.GetByKey(idC);
            context.Remove(idA);
            context.Remove(idB);
            context.Remove(idC);
            var triangle = new Triangle(pointA, pointB, pointC);
            triangle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return triangle;
        }
    }
}

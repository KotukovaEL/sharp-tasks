using Figures.Model;
using Figures.Repositories.Interface;
using System.Collections.Generic;

namespace Figures.Repositories
{
    public class GeometricEntitiesReader : IGeometricEntitiesReader
    {
        private readonly ISourceIO _sourceIO;

        public GeometricEntitiesReader(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public GeometricEntitiesContext ReadFile()
        {
            var context = new GeometricEntitiesContext();
            var lines = _sourceIO.ReadAllLines();
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var str = line.Trim();

                GeometricEntity? entity = str switch
                {
                    "- Point" => ReadPoint(map),
                    "- LineSegment" => ReadLineSegment(map, context),
                    "- Circle" => ReadCircle(map, context),
                    "- Rectangle" => ReadRectangle(map, context),
                    "- Triangle" => ReadTriangle(map, context),
                    "- Ring" => ReadRing(map, context),
                    _ => null,
                };

                if (entity is not null)
                {
                    context.Add(entity);
                    map.Clear();
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(str))
                {
                    var parseStr = TxtDbHelpers.ParseDbRecord(str);
                    map.Add(parseStr.key, parseStr.value);
                    continue;
                }
            }

            return context;
        }


        private Point ReadPoint(Dictionary<string, string> map)
        {
            var x = double.Parse(TxtDbHelpers.GetFieldValue(map, "X"));
            var y = double.Parse(TxtDbHelpers.GetFieldValue(map, "Y"));
            var point = new Point(x, y);
            point.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return point;
        }

        private LineSegment ReadLineSegment(Dictionary<string, string> map, GeometricEntitiesContext context)
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

        private Circle ReadCircle(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idPoint = int.Parse(TxtDbHelpers.GetFieldValue(map, "Center"));
            var center = (Point)context.GetByKey(idPoint);
            var radius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Radius"));
            context.Remove(idPoint);
            var circle = new Circle(center, radius);
            circle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return circle;
        }

        private Rectangle ReadRectangle(Dictionary<string, string> map, GeometricEntitiesContext context)
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

        private Triangle ReadTriangle(Dictionary<string, string> map, GeometricEntitiesContext context)
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

        private Ring ReadRing(Dictionary<string, string> map, GeometricEntitiesContext context)
        {
            var idPoint = int.Parse(TxtDbHelpers.GetFieldValue(map, "Center"));
            var center = (Point)context.GetByKey(idPoint);
            var longRadius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Long radius"));
            var shortRadius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Short radius"));
            context.Remove(idPoint);
            var ring = new Ring(center, longRadius, shortRadius);
            ring.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return ring;
        }
    }
}

using Figures.Common.Interfaces;
using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Figures.Repositories
{
    public class GeometricEntitiesTxtDbContext : ITxtDbContext<int, GeometricEntity>
    {
        private readonly ISourceIO _sourceIO;
        private readonly IdGenerator _idGenerator = new();
        public Dictionary<int, GeometricEntity> EntitiesMap { get; } = new();
        public GeometricEntitiesTxtDbContext(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
            ReadFile();
        }

        public GeometricEntity GetByKey(int id)
        {
            if (!EntitiesMap.TryGetValue(id, out var entity))
            {
                throw new ArgumentException($"Entity with id '{id}' was not found.");
            }

            return entity;
        }

        public void Add(GeometricEntity entity)
        {
            entity.Id = _idGenerator.Generate();
            EntitiesMap.Add(entity.Id, entity);
        }

        public void SaveChanges()
        {
            using var stream = _sourceIO.CreateWriter();

            foreach (var entity in EntitiesMap)
            {
                switch (entity.Value)
                {
                    case Point point:
                        SavePoint(stream, point);
                        break;
                    case LineSegment line:
                        SaveLineSegment(stream, line);
                        break;
                    case Circle circle:
                        SaveCircle(stream, circle);
                        break;
                    case Rectangle rectangle:
                        SaveRectangle(stream, rectangle);
                        break;
                    case Triangle triangle:
                        SaveTriangle(stream, triangle);
                        break;
                    case Ring ring:
                        SaveRing(stream, ring);
                        break;
                    default:
                        throw new ArgumentException($"Unknown entity type {entity.GetType().Name}.");
                }
            }
        }

        public void ReadFile()
        {
            var lines = _sourceIO.ReadAllLines();
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var str = line.Trim();

                GeometricEntity? entity = str switch

                {
                    "- Point" => ReadPoint(map),
                    "- LineSegment" => ReadLineSegment(map),
                    "- Circle" => ReadCircle(map),
                    "- Rectangle" => ReadRectangle(map),
                    "- Triangle" => ReadTriangle(map),
                    "- Ring" => ReadRing(map),
                    _ => null,
                };

                if (entity is not null)
                {
                    EntitiesMap.Add(entity.Id, entity);
                    map.Clear();
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(str))
                {
                    var parseStr = TxtDbHelpers.ParseDbRecord(str);
                    map.Add(parseStr.key, parseStr.value);
                    continue;
                }

                _idGenerator.Reload(EntitiesMap);
            }
        }


        private Point ReadPoint(Dictionary<string, string> map)
        {
            var x = double.Parse(TxtDbHelpers.GetFieldValue(map, "X"));
            var y = double.Parse(TxtDbHelpers.GetFieldValue(map, "Y"));
            var point = new Point(x, y);
            point.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return point;
        }

        private LineSegment ReadLineSegment(Dictionary<string, string> map)
        {
            var idA = int.Parse(TxtDbHelpers.GetFieldValue(map, "A"));
            var idB = int.Parse(TxtDbHelpers.GetFieldValue(map, "B"));
            var pointA = (Point)GetByKey(idA);
            var pointB = (Point)GetByKey(idB);
            EntitiesMap.Remove(idA);
            EntitiesMap.Remove(idB);
            var lineSegment = new LineSegment(pointA, pointB);
            lineSegment.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return lineSegment;
        }

        private Circle ReadCircle(Dictionary<string, string> map)
        {
            var idPoint = int.Parse(TxtDbHelpers.GetFieldValue(map, "Center"));
            var center = (Point)GetByKey(idPoint);
            var radius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Radius"));
            EntitiesMap.Remove(idPoint);
            var circle = new Circle(center, radius);
            circle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return circle;
        }

        private Rectangle ReadRectangle(Dictionary<string, string> map)
        {
            var idA = int.Parse(TxtDbHelpers.GetFieldValue(map, "A"));
            var idB = int.Parse(TxtDbHelpers.GetFieldValue(map, "B"));
            var idC = int.Parse(TxtDbHelpers.GetFieldValue(map, "C"));
            var idD = int.Parse(TxtDbHelpers.GetFieldValue(map, "D"));
            var pointA = (Point)GetByKey(idA);
            var pointB = (Point)GetByKey(idB);
            var pointC = (Point)GetByKey(idC);
            var pointD = (Point)GetByKey(idD);
            EntitiesMap.Remove(idA);
            EntitiesMap.Remove(idB);
            EntitiesMap.Remove(idC);
            EntitiesMap.Remove(idD);
            var rectangle = new Rectangle(pointA, pointB, pointC, pointD);
            rectangle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return rectangle;
        }


        private Triangle ReadTriangle(Dictionary<string, string> map)
        {
            var idA = int.Parse(TxtDbHelpers.GetFieldValue(map, "A"));
            var idB = int.Parse(TxtDbHelpers.GetFieldValue(map, "B"));
            var idC = int.Parse(TxtDbHelpers.GetFieldValue(map, "C"));
            var pointA = (Point)GetByKey(idA);
            var pointB = (Point)GetByKey(idB);
            var pointC = (Point)GetByKey(idC);
            EntitiesMap.Remove(idA);
            EntitiesMap.Remove(idB);
            EntitiesMap.Remove(idC);
            var triangle = new Triangle(pointA, pointB, pointC);
            triangle.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return triangle;
        }

        private Ring ReadRing(Dictionary<string, string> map)
        {
            var idPoint = int.Parse(TxtDbHelpers.GetFieldValue(map, "Center"));
            var center = (Point)GetByKey(idPoint);
            var longRadius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Long radius"));
            var shortRadius = double.Parse(TxtDbHelpers.GetFieldValue(map, "Short radius"));
            EntitiesMap.Remove(idPoint);
            var ring = new Ring(center, longRadius, shortRadius);
            ring.Id = int.Parse(TxtDbHelpers.GetFieldValue(map, "Id"));
            return ring;
        }

        private void SavePoint(TextWriter stream, Point point)
        {
            stream.WriteLine($" Id: {point.Id}");
            stream.WriteLine($" X: {point.X}");
            stream.WriteLine($" Y: {point.Y}");
            stream.WriteLine("- Point");
            stream.WriteLine();
        }

        private void SaveLineSegment(TextWriter stream, LineSegment line)
        {
            line.A.Id = _idGenerator.Generate();
            SavePoint(stream, line.A);
            line.B.Id = _idGenerator.Generate();
            SavePoint(stream, line.B);
            stream.WriteLine($" Id: {line.Id}");
            stream.WriteLine($" A: {line.A.Id}");
            stream.WriteLine($" B: {line.B.Id}");
            stream.WriteLine("- LineSegment");
            stream.WriteLine();
        }

        private void SaveCircle(TextWriter stream, Circle circle)
        {
            circle.Center.Id = _idGenerator.Generate();
            SavePoint(stream, circle.Center);
            stream.WriteLine($" Id: {circle.Id}");
            stream.WriteLine($" Center: {circle.Center.Id}");
            stream.WriteLine($" Radius: {circle.Radius}");
            stream.WriteLine("- Circle");
            stream.WriteLine();
        }

        private void SaveRectangle(TextWriter stream, Rectangle rectangle)
        {
            rectangle.A.Id = _idGenerator.Generate();
            SavePoint(stream, rectangle.A);
            rectangle.B.Id = _idGenerator.Generate();
            SavePoint(stream, rectangle.B);
            rectangle.C.Id = _idGenerator.Generate();
            SavePoint(stream, rectangle.C);
            rectangle.D.Id = _idGenerator.Generate();
            SavePoint(stream, rectangle.D);
            stream.WriteLine($" Id: {rectangle.Id}");
            stream.WriteLine($" A: {rectangle.A.Id}");
            stream.WriteLine($" B: {rectangle.B.Id}");
            stream.WriteLine($" C: {rectangle.C.Id}");
            stream.WriteLine($" D: {rectangle.D.Id}");
            stream.WriteLine("- Rectangle");
            stream.WriteLine();
        }


        private void SaveTriangle(TextWriter stream, Triangle triangle)
        {
            triangle.A.Id = _idGenerator.Generate();
            SavePoint(stream, triangle.A);
            triangle.B.Id = _idGenerator.Generate();
            SavePoint(stream, triangle.B);
            triangle.C.Id = _idGenerator.Generate();
            SavePoint(stream, triangle.C);
            stream.WriteLine($" Id: {triangle.Id}");
            stream.WriteLine($" A: {triangle.A.Id}");
            stream.WriteLine($" B: {triangle.B.Id}");
            stream.WriteLine($" C: {triangle.C.Id}");
            stream.WriteLine("- Triangle");
            stream.WriteLine();
        }

        private void SaveRing(TextWriter stream, Ring ring)
        {
            ring.Center.Id = _idGenerator.Generate();
            SavePoint(stream, ring.Center);
            stream.WriteLine($" Id: {ring.Id}");
            stream.WriteLine($" Center: {ring.Center.Id}");
            stream.WriteLine($" Long radius: {ring.BigCircle.Radius}");
            stream.WriteLine($" Short radius: {ring.SmallCircle.Radius}");
            stream.WriteLine("- Ring");
            stream.WriteLine();
        }
    }
}

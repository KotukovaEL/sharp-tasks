using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Figures.Repositories
{
    public class TxtDbContext
    {
        private readonly IdGenerator _idGenerator = new();
        private readonly Dictionary<int, GeometricEntity> _entitiesMap = new();
        private readonly string _filePath;        

        public TxtDbContext(string filePath)
        {
            _filePath = filePath;
            ReadFile();
        }

        public List<GeometricEntity> List()
        {
            return _entitiesMap.Select(x => x.Value).OrderBy(x => x.Id).ToList();
        }

        public void Add(GeometricEntity entity)
        {
            entity.Id = _idGenerator.Generate();
            _entitiesMap.Add(entity.Id, entity);
        }

        public void DeleteAll()
        {
            _entitiesMap.Clear();
        }

        public void SaveChanges()
        {
            using var fs = new FileStream(_filePath, FileMode.Create);
            using var stream = new StreamWriter(fs);

            foreach (var entity in _entitiesMap)
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
                    default: 
                        throw new ArgumentException($"Unknown entity type {entity.GetType().Name}.");
                }
            }
        }

        public void ReadFile() 
        {
            string[] lines = File.ReadAllLines(_filePath);
            var map = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                if (line.Contains("Point"))
                {
                    var point = ReadPoint(map);
                    _entitiesMap.Add(point.Id, point);
                    map.Clear();
                    continue;
                }

                if (line.Contains("LineSegment"))
                {
                    var lineSegment = ReadLineSegment(map);
                    _entitiesMap.Add(lineSegment.Id, lineSegment);
                    map.Clear();
                    continue;
                }

                if (line.Contains("Circle"))
                {
                    var circle = ReadCircle(map);
                    _entitiesMap.Add(circle.Id, circle);
                    map.Clear();
                    continue;
                }

                if (line.Contains("Rectangle"))
                {
                    var rectangle = ReadRectangle(map);
                    _entitiesMap.Add(rectangle.Id, rectangle);
                    map.Clear();
                    continue;
                }

                if (line.Contains("Triangle"))
                {
                    var triangle = ReadTriangle(map);
                    _entitiesMap.Add(triangle.Id, triangle);
                    map.Clear();
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(line))
                {
                    var str = line.Trim();
                    var separator = ": ";
                    var separatorIndex = str.IndexOf(separator);
                    var key = str.Substring(0, separatorIndex);
                    var value = str.Substring(separatorIndex + separator.Length);
                    map.Add(key, value);
                    continue;
                }

                _idGenerator.Reload(_entitiesMap);
            }
        }


        private Point ReadPoint(Dictionary<string, string> map)
        {
            var x = double.Parse(GetFieldValue(map, "X"));
            var y = double.Parse(GetFieldValue(map, "Y"));
            var point = new Point(x, y);
            point.Id = int.Parse(GetFieldValue(map, "Id"));
            return point;
        }

        private string GetFieldValue(Dictionary<string, string> map, string key)
        {
            if (!map.TryGetValue(key, out var value))
            {
                throw new ArgumentException($"Field {key} was not found.");
            }

            return value;
        }

        private LineSegment ReadLineSegment(Dictionary<string, string> map)
        {
            var idA = int.Parse(GetFieldValue(map, "A"));
            var idB = int.Parse(GetFieldValue(map, "B"));
            var pointA = (Point)GetEntityById(idA);
            var pointB = (Point)GetEntityById(idB);
            _entitiesMap.Remove(idA);
            _entitiesMap.Remove(idB);
            var lineSegment = new LineSegment(pointA, pointB);
            lineSegment.Id = int.Parse(GetFieldValue(map, "Id"));            
            return lineSegment;
        }

        private Circle ReadCircle(Dictionary<string, string> map)
        {
            var idPoint = int.Parse(GetFieldValue(map, "Center"));
            var center = (Point)GetEntityById(idPoint);
            var radius = double.Parse(GetFieldValue(map, "Radius"));
            _entitiesMap.Remove(idPoint);
            var circle = new Circle(center, radius);
            circle.Id = int.Parse(GetFieldValue(map, "Id"));
            return circle;
        }

        private Rectangle ReadRectangle(Dictionary<string, string> map)
        {
            var idA = int.Parse(GetFieldValue(map, "A"));
            var idB = int.Parse(GetFieldValue(map, "B"));
            var idC = int.Parse(GetFieldValue(map, "C"));
            var idD = int.Parse(GetFieldValue(map, "D"));
            var pointA = (Point)GetEntityById(idA);
            var pointB = (Point)GetEntityById(idB);
            var pointC = (Point)GetEntityById(idC);
            var pointD = (Point)GetEntityById(idD);
            _entitiesMap.Remove(idA);
            _entitiesMap.Remove(idB);
            _entitiesMap.Remove(idC);
            _entitiesMap.Remove(idD);
            var rectangle = new Rectangle(pointA, pointB, pointC, pointD);
            rectangle.Id = int.Parse(GetFieldValue(map, "Id"));
            return rectangle;
        }


        private Triangle ReadTriangle(Dictionary<string, string> map)
        {
            var idA = int.Parse(GetFieldValue(map, "A"));
            var idB = int.Parse(GetFieldValue(map, "B"));
            var idC = int.Parse(GetFieldValue(map, "C"));
            var pointA = (Point)GetEntityById(idA);
            var pointB = (Point)GetEntityById(idB);
            var pointC = (Point)GetEntityById(idC);
            _entitiesMap.Remove(idA);
            _entitiesMap.Remove(idB);
            _entitiesMap.Remove(idC);
            var triangle = new Triangle(pointA, pointB, pointC);
            triangle.Id = int.Parse(GetFieldValue(map, "Id"));
            return triangle;
        }


        private GeometricEntity GetEntityById(int id)
        {
            if (!_entitiesMap.TryGetValue(id, out var entity))
            {
                throw new ArgumentException($"Entity with id '{id}' was not found.");
            }

            return entity;
        }

        private void SavePoint(StreamWriter stream, Point point)
        {          
            stream.WriteLine($" Id: {point.Id}");
            stream.WriteLine($" X: {point.X}");
            stream.WriteLine($" Y: {point.Y}");
            stream.WriteLine("- Point");
            stream.WriteLine();
        }

        private void SaveLineSegment(StreamWriter stream, LineSegment line) 
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

        private void SaveCircle(StreamWriter stream, Circle circle)
        {
            circle.Center.Id = _idGenerator.Generate();
            SavePoint(stream, circle.Center);
            stream.WriteLine($" Id: {circle.Id}");
            stream.WriteLine($" Center: {circle.Center.Id}");
            stream.WriteLine($" Radius: {circle.Radius}");
            stream.WriteLine("- Circle");
            stream.WriteLine();
        }

        private void SaveRectangle(StreamWriter stream, Rectangle rectangle)
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


        private void SaveTriangle(StreamWriter stream, Triangle triangle)
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

        private class IdGenerator
        {
            private readonly HashSet<int> _ids = new();

            public void Reload(Dictionary<int, GeometricEntity> entity)
            {
                var id = entity.Keys.Select(x => x).ToList();

                foreach (var key in id)
                {
                    _ids.Add(key);
                }
            }

            public int Generate() 
            {

                int id = _ids.Count == 0 ? 1 : _ids.Max();

                if (_ids.Count != 0)
                {
                    id = _ids.Max() + 1;
                }

                _ids.Add(id);
                return id;
            }
        }
    }
}

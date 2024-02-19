using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Figures.Repositories
{
    public class TxtDbContext
    {
        private readonly Dictionary<int, GeometricEntity> _entitiesMap;
        private readonly string _filePath;

        public TxtDbContext(string filePath)
        {
            _entitiesMap = new();
            _filePath = filePath;
            ReadFile();            
        }

        public List<GeometricEntity> List()
        {
            return _entitiesMap.Select(x => x.Value).OrderBy(x => x.Id).ToList();
        }

        public void Add(GeometricEntity entity)
        {
            entity.Id = GenerateId();
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
            }
        }

        private Point ReadPoint(Dictionary<string, string> map)
        {
            var x = double.Parse(GetFieldValue(map, "X"));
            var y = double.Parse(GetFieldValue(map, "Y"));
            var point = new Point(x, y);
            point.Id = int.Parse(GetFieldValue(map, "Id")); ;
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


        private GeometricEntity GetEntityById(int id)
        {
            if (!_entitiesMap.TryGetValue(id, out var entity))
            {
                throw new ArgumentException($"Entity with id '{id}' was not found.");
            }

            return entity;
        }

        private int SavePoint(StreamWriter stream, Point point)
        {
            var id = GenerateId();            
            stream.WriteLine($" Id: {id}");
            stream.WriteLine($" X: {point.X}");
            stream.WriteLine($" Y: {point.Y}");
            stream.WriteLine("- Point");
            stream.WriteLine();
            return id;
        }

        private int SaveLineSegment(StreamWriter stream, LineSegment line) 
        {
            var id = GenerateId();
            var AId = SavePoint(stream, line.A);
            var BId = SavePoint(stream, line.B);
            stream.WriteLine($" Id: {id}");
            stream.WriteLine($" A: {AId}");
            stream.WriteLine($" B: {BId}");
            stream.WriteLine("- LineSegment");
            stream.WriteLine();
            return id;
        }

        private int GenerateId()
        {
            if (_entitiesMap.Count == 0)
            {
                return 1;
            }

            var maxId = _entitiesMap.Select(x => x.Key).Max();
            return maxId + 1;
        }
    }
}

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

        public TxtDbContext()
        {
            _entitiesMap = new();
            ReadFile();
        }
        //должен принимать список поинтов (метод), конвертировать в определенный формат, записывать в файл
        //из файла создать список поинтов и вернуть

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
            var path = @"C:\Users\Дмитрий\source\repos\sharp-tasks\Task4\Figures\MyFile.txt";
            using var fs = new FileStream(path, FileMode.Create);
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
            var path = @"C:\Users\Дмитрий\source\repos\sharp-tasks\Task4\Figures\MyFile.txt";
            using var fs = new StreamReader(path);
            string[] lines = File.ReadAllLines(path);
            var list = new List<string>();

            foreach (var str in lines)
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    list.Add(str);
                    continue;
                }

                if (list[0].Contains("Point"))
                {
                    ReadPoint(list);
                    list.Clear();
                    continue;
                }

                if (list[0].Contains("LineSegment"))
                {
                    ReadLineSegment(list);
                    list.Clear();
                    continue;
                }
            }
        }

        private void ReadPoint(List<string> list)
        {
            double? x = null;
            double? y = null;
            int id = 0;

            foreach (var line in list)
            {
                if (line.Contains("Id: "))
                {
                    id = ReadId(line);
                }

                if (line.Contains('X'))
                {
                    var str = ReadStrForPoint(line, "X: ");
                    x = double.Parse(str);
                }

                if (line.Contains('Y'))
                {
                    var str = ReadStrForPoint(line, "Y: ");
                    y = double.Parse(str);
                }

                if (x is not null & y is not null)
                {
                    var point = new Point(x.Value, y.Value);
                    point.Id = id;
                    _entitiesMap.Add(id, point);
                    x = null; y = null;
                }
            }
        }

        private void ReadLineSegment(List<string> list)
        {
            int id = 0;
            Point? point1 = null;
            Point? point2 = null;

            foreach (var line in list)
            {
                if (line.Contains("Id: "))
                {
                    id = ReadId(line);
                }

                if (line.Contains("A: "))
                {
                    var str = ReadStrForLineSegment(line, "A: ", "; ");
                    point1 = GetEntityById(str.id) as Point;
                }

                if (line.Contains("B: "))
                {
                    var str = ReadStrForLineSegment(line, "B: ", "; ");
                    point2 = GetEntityById(str.id) as Point;
                }

                if (point1 is not null & point2 is not null)
                {
                    var lineSegment = new LineSegment(point1, point2);
                    lineSegment.Id = id;
                    _entitiesMap.Add(id, lineSegment);
                    _entitiesMap.Remove(point1.Id);
                    _entitiesMap.Remove(point2.Id);
                    point1 = null; point2 = null;
                }

            }
        }

        private GeometricEntity GetEntityById(int id)
        {
            if (!_entitiesMap.TryGetValue(id, out var entity))
            {
                throw new ArgumentException($"Entity with id '{id}' was not found.");
            }

            return entity;
        }

        private (string type, int id) ReadStrForLineSegment(string line, string key1, string key2)
        {
            var startIndexKey1 = line.IndexOf(key1);
            var lengthKey1 = key1.Length;
            var lastIndexKey1 = lengthKey1 + startIndexKey1;
            var startIndexKey2 = line.IndexOf(key2);
            var lengthKey2 = key2.Length;
            var number1 = line.Substring(lastIndexKey1, startIndexKey2 - lastIndexKey1);
            var number2 = line.Substring(startIndexKey2 + lengthKey2);
            var idPoint1 = int.Parse(number2);

            return (number1, idPoint1);
        }

        private string ReadStrForPoint(string line, string str)
        {
            var key = str;
            var startIndexKey = line.IndexOf(key);
            var lengthKey = key.Length;
            return line.Substring(startIndexKey + lengthKey);
        }

        private int ReadId(string line)
        {
            var key = "Id: ";
            var startIndexKey = line.IndexOf(key);
            var lengthKey = key.Length;
            var number = line.Substring(startIndexKey + lengthKey);
            var id = int.Parse(number);
            return id;
        }

        private int SavePoint(StreamWriter stream, Point point)
        {
            var id = GenerateId();
            stream.WriteLine("- Point");
            stream.WriteLine($" Id: {id}");
            stream.WriteLine($" X: {point.X}");
            stream.WriteLine($" Y: {point.Y}");
            stream.WriteLine();

            return id;
        }

        private int SaveLineSegment(StreamWriter stream, LineSegment line) 
        {
            var id = GenerateId();
            var AId = SavePoint(stream, line.A);
            var BId = SavePoint(stream, line.B);
            stream.WriteLine("- LineSegment");
            stream.WriteLine($" Id: {id}");
            stream.WriteLine($" A: Point; {AId}");
            stream.WriteLine($" B: Point; {BId}");
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

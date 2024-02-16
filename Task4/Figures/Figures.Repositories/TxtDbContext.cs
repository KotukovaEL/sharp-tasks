using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Figures.Repositories
{
    public class TxtDbContext
    {
        public List<GeometricEntity> GeometricEntities { get;}

        public TxtDbContext()
        {
            GeometricEntities = new List<GeometricEntity>();
            ReadFile();
        }
        //должен принимать список поинтов (метод), конвертировать в определенный формат, записывать в файл
        //из файла создать список поинтов и вернуть
        public void SaveChange()
        {
            var path = @"D:\programming\с#\Test_Tasks\sharp-tasks\Task4\Figures\MyFile.txt";
            using var fs = new FileStream(path, FileMode.Create);
            using var stream = new StreamWriter(fs);
            var idGenerator = new IdGenerator();

            foreach (var element in GeometricEntities)
            {
                switch (element)
                {
                    case Point point:
                        SavePoint(stream, point, idGenerator);
                        break;
                    case LineSegment line:
                        SaveLineSegment(stream, line, idGenerator);
                        break;
                    default: 
                        throw new ArgumentException($"Unknown entity type {element.GetType().Name}.");
                }
            }
        }

        public void ReadFile() 
        {
            var path = @"D:\programming\с#\Test_Tasks\sharp-tasks\Task4\Figures\MyFile.txt";
            using var fs = new StreamReader(path);
            string[] lines = File.ReadAllLines(path);
            var list = new List<string>();

            foreach (var str in lines)
            {
                if (string.IsNullOrEmpty(str))
                {
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
                else
                {
                    list.Add(str);
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
                    GeometricEntities.Add(point);
                    point.Id = id;
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
                    point1 =AssignDataForPoint(str.Item1, str.Item2);
                    
                }

                if (line.Contains("B: "))
                {
                    var str = ReadStrForLineSegment(line, "B: ", "; ");
                    point2 = AssignDataForPoint(str.Item1, str.Item2);
                }

                if (point1 is not null & point2 is not null)
                {
                    var lineSegment = new LineSegment(point1, point2);
                    GeometricEntities.Add(lineSegment);
                    GeometricEntities.Remove(point1);
                    GeometricEntities.Remove(point2);
                    lineSegment.Id = id;
                    point1 = null; point2 = null;
                }

            }
        }

        private Point AssignDataForPoint(string item1, int item2)
        {
            Point? point = null;

            if (item1 == "Point")
            {
                foreach (var element in GeometricEntities)
                {
                    if (element.Id == item2)
                    {
                        point = element as Point;
                    }
                }
            }

            return point;
        }

        private (string, int) ReadStrForLineSegment(string line, string str1, string str2)
        {
            var key1 = str1;
            var key2 = str2;
            var startIndexKey1 = line.IndexOf(key1);
            var lengthKey1 = key1.Length;
            var lastIndexKey1 = lengthKey1 + startIndexKey1;
            var startIndexKey2 = line.IndexOf(key2);
            var lengthKey2 = key2.Length;
            var number1 = line.Substring(lastIndexKey1, startIndexKey2 - lastIndexKey1);
            var number2 = line.Substring(startIndexKey2 + lengthKey2);
            var idPont1 = int.Parse(number2);

            return (number1, idPont1);
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

        private int SavePoint(StreamWriter stream, Point point, IdGenerator idGenerator)
        {
            var id = idGenerator.GenerateId();
            stream.WriteLine("- Point");
            stream.WriteLine($" Id: {id}");
            stream.WriteLine($" X: {point.X}");
            stream.WriteLine($" Y: {point.Y}");
            stream.WriteLine();

            return id;
        }

        private int SaveLineSegment(StreamWriter stream, LineSegment line, IdGenerator idGenerator) 
        {
            var id = idGenerator.GenerateId();
            var AId = SavePoint(stream, line.A, idGenerator);
            var BId = SavePoint(stream, line.B, idGenerator);
            stream.WriteLine("- LineSegment");
            stream.WriteLine($" Id: {id}");
            stream.WriteLine($" A: Point; {AId}");
            stream.WriteLine($" B: Point; {BId}");
            stream.WriteLine();

            return id;
        }


        private class IdGenerator
        {
            private readonly HashSet<int> _ids = new HashSet<int>();

            public int GenerateId()
            {
                var id = 1;

                if (_ids.Count > 0)
                {
                    id = _ids.Max() + 1;
                }
                
                _ids.Add(id);

                return id;
            }
        }
    }
}

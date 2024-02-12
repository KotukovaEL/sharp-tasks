using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Figures.Repositories
{
    public class TxtDbContext
    {
        public List<Point> Points { get;}

        public TxtDbContext()
        {
            Points = new List<Point>();
        }
        //должен принимать список поинтов (метод), конвертировать в определенный формат, записывать в файл
        //из файла создать список поинтов и вернуть
        public void CreateFile() 
        {
            var path = @"D:\programming\с#\Test_Tasks\sharp-tasks\Task4\Figures\MyFile.txt";
            var fs = new FileStream(path, FileMode.Create);
            using var stream = new StreamWriter(fs);
            var i = 1;
            stream.WriteLine("- Points");

            foreach (var point in Points)
            {
                
                stream.WriteLine($" Id: {i}");
                stream.WriteLine($" X: {point.X}");
                stream.WriteLine($" Y: {point.Y}");
                i++;
                stream.WriteLine();
            }
        }

        public void SaveChange()
        {
            CreateFile();
        }

        public void ReadFile() 
        {
            var path = @"D:\programming\с#\Test_Tasks\sharp-tasks\Task4\Figures\MyFile.txt";
            using var fs = new StreamReader(path);
            string[] lines = File.ReadAllLines(path);
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                //char[] chars = line.ToCharArray(); 
                if (line.Contains('X'))
                {
                    var str = line.Where(char.IsDigit).ToArray();
                    sb.Append(str);                   
                }

                if (line.Contains('Y'))
                {
                    sb.Append(line.Where(char.IsDigit).ToArray());
                }

                if (sb.Length >= 2)
                {
                    var point = new Point(sb[0], sb[1]);
                    Points.Add(point);
                    sb.Clear();
                }
            }
            //"Точка: координаты: '{X}','{Y}'."
        }
    }
}

using Figures.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class EntitiesCreator
    {
        public static Circle CreateCircle()
        {
            Console.WriteLine("Введите параметры фигуры Круг");
            Console.WriteLine("Введите координаты центра:");
            var center = CreatePoint();
            Console.WriteLine("Введите радиус круга:");
            var radius = ReadDoubleForRadius(Console.ReadLine());
            Console.WriteLine("Фигура Круг создана!");
            return new Circle(center, radius);
        }

        public static LineSegment CreateLineSegment()
        {
            Console.WriteLine("Введите параметры фигуры Линия");
            Console.WriteLine("Введите координаты первой точки:");
            var point1 = CreatePoint();
            Console.WriteLine("Введите координаты второй точки:");
            var point2 = CreatePoint();
            Console.WriteLine("Линия создана!");
            return new LineSegment(point1, point2);
        }

        public static Rectangle CreateRectangle()
        {
            Console.WriteLine("Введите параметры фигуры Прямоугольник");
            Console.WriteLine("Введите координаты первой точки:");
            var point1 = CreatePoint();
            Console.WriteLine("Введите координаты второй точки:");
            var point2 = CreatePoint();
            Console.WriteLine("Введите координаты третьей точки:");
            var point3 = CreatePoint();
            Console.WriteLine("Введите координаты четвертой точки:");
            Console.WriteLine("Фигура Прямоугольник создана!");
            var point4 = CreatePoint();
            return new Rectangle(point1, point2, point3, point4);
        }

        public static Ring CreateRing()
        {
            Console.WriteLine("Введите параметры фигуры Кольцо");
            Console.WriteLine("Введите координаты центра:");
            var center = CreatePoint();
            Console.WriteLine("Введите радиус большего круга:");
            var longRadius = ReadDoubleForRadius(Console.ReadLine());
            Console.WriteLine("Введите радиус меньшего круга:");
            var shortRadius = ReadDoubleForRadius(Console.ReadLine());
            Console.WriteLine("Фигура Кольцо создана!");
            return new Ring(center, longRadius, shortRadius);
        }

        public static Triangle CreateTriangle()
        {
            Console.WriteLine("Введите параметры фигуры Треугольник");
            Console.WriteLine("Введите координаты первой точки:");
            var point1 = CreatePoint();
            Console.WriteLine("Введите координаты второй точки:");
            var point2 = CreatePoint();
            Console.WriteLine("Введите координаты третьей точки:");
            var point3 = CreatePoint();
            Console.WriteLine("Фигура Треугольник создана!");
            return new Triangle(point1, point2, point3);
        }

        public static Point CreatePoint()
        {
            Console.WriteLine("Введите координаты X:");
            double x = ReadDouble(Console.ReadLine());
            Console.WriteLine("Введите координаты Y:");
            double y = ReadDouble(Console.ReadLine());
            return new Point(x, y);
        }

        public static double ReadDoubleForRadius(string str)
        {
            double value;
            while (!double.TryParse(str, out value) || value < 0)
            {
                Console.WriteLine("Попробуй снова ввести");
                str = Console.ReadLine();
            }

            return value;
        }

        public static double ReadDouble(string str)
        {
            double value;

            while (!double.TryParse(str, out value))
            {
                Console.WriteLine("Попробуй снова ввести");
                str = Console.ReadLine();
            }

            return value;
        }
    }
}

using Figures.Model;
using InterfaceFigure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class EntitiesCreator
    {
        private readonly IUserInteractor _userInteractor;

        public EntitiesCreator(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }
        public Circle CreateCircle()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Круг");
            _userInteractor.PrintMessage("Введите координаты центра:");
            var center = CreatePoint();
            _userInteractor.PrintMessage("Введите радиус круга:");
            var radius = Converter.ReadDouble(_userInteractor.ReadValue(), _userInteractor);
            return new Circle(center, radius);
        }

        public LineSegment CreateLineSegment()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Линия");
            _userInteractor.PrintMessage("Введите координаты первой точки:");
            var point1 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты второй точки:");
            var point2 = CreatePoint();
            return new LineSegment(point1, point2);
        }

        public Rectangle CreateRectangle()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Прямоугольник");
            _userInteractor.PrintMessage("Введите координаты первой точки:");
            var point1 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты второй точки:");
            var point2 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты третьей точки:");
            var point3 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты четвертой точки:");
            var point4 = CreatePoint();
            return new Rectangle(point1, point2, point3, point4);
        }

        public Ring CreateRing()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Кольцо");
            _userInteractor.PrintMessage("Введите координаты центра:");
            var center = CreatePoint();
            _userInteractor.PrintMessage("Введите радиус большего круга:");
            var longRadius = Converter.ReadDouble(_userInteractor.ReadValue(), _userInteractor);
            _userInteractor.PrintMessage("Введите радиус меньшего круга:");
            var shortRadius = Converter.ReadDouble(_userInteractor.ReadValue(), _userInteractor);
            return new Ring(center, longRadius, shortRadius);
        }

        public Triangle CreateTriangle()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Треугольник");
            _userInteractor.PrintMessage("Введите координаты первой точки:");
            var point1 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты второй точки:");
            var point2 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты третьей точки:");
            var point3 = CreatePoint();
            return new Triangle(point1, point2, point3);
        }

        public Point CreatePoint()
        {
            _userInteractor.PrintMessage("Введите координаты X:");
            double x = Converter.ReadDouble(_userInteractor.ReadValue(), _userInteractor);
            _userInteractor.PrintMessage("Введите координаты Y:");
            double y = Converter.ReadDouble(_userInteractor.ReadValue(), _userInteractor);
            return new Point(x, y);
        }
    }
}

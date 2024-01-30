using Figures.Model;
using InterfaceFigure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class EntitiesCreator : IEntitiesCreator
    {
        private readonly IUserInteractor _userInteractor;

        public EntitiesCreator(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public GeometricEntity CreateEntity()
        {
            var type = ReadEntityType();
            return CreateEntityByType(type);
        }

        private GeometricEntityTypes ReadEntityType()
        {
            MenuHelpers.PrintGeometricEntityTypes(_userInteractor);

            if (!EnumHelpers.TryReadEnum(_userInteractor.ReadStr(), out GeometricEntityTypes type))
            {
                return GeometricEntityTypes.None;
            }

            return type;
        }

        private GeometricEntity CreateEntityByType(GeometricEntityTypes geometricFigure) => geometricFigure switch
        {
            GeometricEntityTypes.Circle => CreateCircle(),
            GeometricEntityTypes.LineSegment => CreateLineSegment(),
            GeometricEntityTypes.Rectangle => CreateRectangle(),
            GeometricEntityTypes.Ring => CreateRing(),
            GeometricEntityTypes.Triangle => CreateTriangle(),
            GeometricEntityTypes.Point => CreatePoint(),
            _ => throw new ArgumentException("There is no such figure."),
        };

        private Circle CreateCircle()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Круг");
            _userInteractor.PrintMessage("Введите координаты центра:");
            var center = CreatePoint();
            _userInteractor.PrintMessage("Введите радиус круга:");
            var radius = Reader.ReadDouble(_userInteractor);
            return new Circle(center, radius);
        }

        private LineSegment CreateLineSegment()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Линия");
            _userInteractor.PrintMessage("Введите координаты первой точки:");
            var point1 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты второй точки:");
            var point2 = CreatePoint();
            return new LineSegment(point1, point2);
        }

        private Rectangle CreateRectangle()
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

        private Ring CreateRing()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Кольцо");
            _userInteractor.PrintMessage("Введите координаты центра:");
            var center = CreatePoint();
            _userInteractor.PrintMessage("Введите радиус большего круга:");
            var longRadius = Reader.ReadDouble(_userInteractor);
            _userInteractor.PrintMessage("Введите радиус меньшего круга:");
            var shortRadius = Reader.ReadDouble(_userInteractor);
            return new Ring(center, longRadius, shortRadius);
        }

        private Triangle CreateTriangle()
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

        private Point CreatePoint()
        {
            _userInteractor.PrintMessage("Введите координаты X:");
            double x = Reader.ReadDouble(_userInteractor);
            _userInteractor.PrintMessage("Введите координаты Y:");
            double y = Reader.ReadDouble(_userInteractor);
            return new Point(x, y);
        }
    }
}

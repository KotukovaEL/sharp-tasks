﻿using Figures.Model;
using System;

namespace Figures.Handlers
{
    public class EntitiesCreator : IEntitiesCreator
    {
        private readonly IUserInteractor _userInteractor;
        private readonly Validation _validation = new Validation();

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
            var radius = ReadHelpers.ReadDouble(_userInteractor);
            _validation.ValidateCircle(radius);
            return new Circle { 
                Center = center,
                Radius = radius
            };
        }

        private LineSegment CreateLineSegment()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Линия");
            _userInteractor.PrintMessage("Введите координаты первой точки:");
            var point1 = CreatePoint();
            _userInteractor.PrintMessage("Введите координаты второй точки:");
            var point2 = CreatePoint();
            _validation.ValidateLineSegment(point1, point2);
            return new LineSegment
            {
                A = point1,
                B = point2
            };
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
            _validation.ValidateRectangle(point1, point2, point3, point4);
            return new Rectangle {
                A = point1,
                B = point2,
                C = point3,
                D = point4,            
            };
        }

        private Ring CreateRing()
        {
            _userInteractor.PrintMessage("Введите параметры фигуры Кольцо");
            _userInteractor.PrintMessage("Введите координаты центра:");
            var center = CreatePoint();
            _userInteractor.PrintMessage("Введите радиус большего круга:");
            var longRadius = ReadHelpers.ReadDouble(_userInteractor);
            _userInteractor.PrintMessage("Введите радиус меньшего круга:");
            var shortRadius = ReadHelpers.ReadDouble(_userInteractor);
            _validation.ValidateRing(longRadius, shortRadius);
            return new Ring {
                Center = center,
                BigCircleRadius = longRadius,
                SmallCircleRadius = shortRadius
            };
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
            _validation.ValidateTriangle(point1, point2, point3);
            return new Triangle {
                A = point1,
                B = point2,
                C = point3,
            };
        }

        private Point CreatePoint()
        {
            _userInteractor.PrintMessage("Введите координаты X:");
            double x = ReadHelpers.ReadDouble(_userInteractor);
            _userInteractor.PrintMessage("Введите координаты Y:");
            double y = ReadHelpers.ReadDouble(_userInteractor);
            return new Point {
                X = x,
                Y = y
            };
        }
    }
}

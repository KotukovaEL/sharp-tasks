using Figures.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Services.Tests
{

    public class EntitiesCreatorTests
    {
        private readonly StringBuilder _outputSb;
        private string[] _inputs;
        private int _inputIndex;

        public EntitiesCreatorTests()
        {
            _outputSb = new StringBuilder();
            _inputIndex = 0;
        }


        [Fact]
        public void Should_create_point_correctly()
        {
            _inputs = new[] { "6","2", "3" };
            var logic = CreateEntitiesCreator();
            var figure = logic.CreateEntity();

            string expectedOutput = string.Join(null,
                "Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите координаты X:",
                "Введите координаты Y:");
            var expectedEntity = new Point(2, 3);

            Assert.Equal(expectedOutput, _outputSb.ToString());
            Assert.Equivalent(expectedEntity, figure);
        }

        [Fact]
        public void Should_create_circle_correctly()
        {
            _inputs = new[] { "1", "2", "3", "5" };
            var logic = CreateEntitiesCreator();
            var entity = logic.CreateEntity();

            string expectedOutput = string.Join(null,
                "Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Круг",
                "Введите координаты центра:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите радиус круга:");

            var point = new Point(2, 3);
            var expectedEntity = new Circle(point, 5);

            Assert.Equal(expectedOutput, _outputSb.ToString());
            Assert.Equivalent(expectedEntity, entity);
        }

        [Fact]
        public void Should_create_line_segment_correctly()
        {
            _inputs = new[] { "2", "2", "3", "5", "6" };
            var logic = CreateEntitiesCreator();
            var entity = logic.CreateEntity();

            string expectedOutput = string.Join(null,
                "Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Линия",
                "Введите координаты первой точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите координаты второй точки:",
                "Введите координаты X:",
                "Введите координаты Y:");

            var point1 = new Point(2, 3);
            var point2 = new Point(5, 6);
            var expectedEntity = new LineSegment(point1, point2);

            Assert.Equal(expectedOutput, _outputSb.ToString());
            Assert.Equivalent(expectedEntity, entity);
        }

        [Fact]
        public void Should_create_rectangle_correctly()
        {
            _inputs = new[] { "3", "-1", "-3", "-1", "1", "5", "1", "5", "-3" };
            var logic = CreateEntitiesCreator();
            var entity = logic.CreateEntity();

            string expectedOutput = string.Join(null,
                "Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Прямоугольник",
                "Введите координаты первой точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите координаты второй точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите координаты третьей точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите координаты четвертой точки:",
                "Введите координаты X:",
                "Введите координаты Y:");

            var point1 = new Point(-1, -3);
            var point2 = new Point(-1, 1);
            var point3 = new Point(5, 1);
            var point4 = new Point(5, -3);
            var expectedEntity = new Rectangle(point1, point2, point3, point4);

            Assert.Equal(expectedOutput, _outputSb.ToString());
            Assert.Equivalent(expectedEntity, entity);
        }

        [Fact]
        public void Should_create_ring_correctly()
        {
            _inputs = new[] { "4", "1", "3", "5", "1" };
            var logic = CreateEntitiesCreator();
            var entity = logic.CreateEntity();

            string expectedOutput = string.Join(null,
                "Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Кольцо",
                "Введите координаты центра:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите радиус большего круга:",
                "Введите радиус меньшего круга:");

            var point = new Point(1, 3);
            var expectedEntity = new Ring(point, 5, 1);

            Assert.Equal(expectedOutput, _outputSb.ToString());
            Assert.Equivalent(expectedEntity, entity);
        }

        [Fact]
        public void Should_create_triangle_correctly()
        {
            _inputs = new[] { "5", "1", "3", "1", "1", "5", "1" };
            var logic = CreateEntitiesCreator();
            var entity = logic.CreateEntity();

            string expectedOutput = string.Join(null,
                "Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Треугольник",
                "Введите координаты первой точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                 "Введите координаты второй точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите координаты третьей точки:",
                "Введите координаты X:",
                "Введите координаты Y:");

            var point1 = new Point(1, 3);
            var point2 = new Point(1, 1);
            var point3 = new Point(5, 1);
            var expectedEntity = new Triangle(point1, point2, point3);

            Assert.Equal(expectedOutput, _outputSb.ToString());
            Assert.Equivalent(expectedEntity, entity);
        }
        private EntitiesCreator CreateEntitiesCreator()
        {
            var interactor = new Mock<IUserInteractor>();

            interactor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) =>
                {
                    _outputSb.Append(message);
                });

            interactor
                .Setup(x => x.ReadStr())
                .Returns(() =>
                {
                    var input = _inputs[_inputIndex];
                    _inputIndex++;
                    return input;
                });

            return new EntitiesCreator(interactor.Object);
        }
    }
}

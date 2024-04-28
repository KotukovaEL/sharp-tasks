using Figures.Model;
using FluentAssertions;
using Moq;
using System.Text;
using Xunit;

namespace Figures.Handlers.Tests
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
            _inputs = new[] { "6", "2", "3" };
            var creator = CreateEntitiesCreator();
            var entity = creator.CreateEntity();

            string expectedOutput = string.Join(null,
                "\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите координаты X:",
                "Введите координаты Y:");
            var expectedEntity = new Point { X = 2, Y = 3 };

            Assert.Equal(expectedOutput, _outputSb.ToString());
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public void Should_create_circle_correctly()
        {
            _inputs = new[] { "1", "2", "3", "5" };
            var creator = CreateEntitiesCreator();
            var entity = creator.CreateEntity();

            string expectedOutput = string.Join(null,
                "\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Круг",
                "Введите координаты центра:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите радиус круга:");

            var point = new Point { X = 2, Y = 3 };
            var expectedEntity = new Circle { Center = point, Radius = 5 };

            Assert.Equal(expectedOutput, _outputSb.ToString());
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public void Should_create_line_segment_correctly()
        {
            _inputs = new[] { "2", "2", "3", "5", "6" };
            var creator = CreateEntitiesCreator();
            var entity = creator.CreateEntity();

            string expectedOutput = string.Join(null,
                "\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Линия",
                "Введите координаты первой точки:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите координаты второй точки:",
                "Введите координаты X:",
                "Введите координаты Y:");

            var point1 = new Point { X = 2, Y = 3 };
            var point2 = new Point { X = 5, Y = 6 };
            var expectedEntity = new LineSegment { A = point1, B = point2 };

            Assert.Equal(expectedOutput, _outputSb.ToString());
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public void Should_create_rectangle_correctly()
        {
            _inputs = new[] { "3", "-1", "-3", "-1", "1", "5", "1", "5", "-3" };
            var creator = CreateEntitiesCreator();
            var entity = creator.CreateEntity();

            string expectedOutput = string.Join(null,
                "\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
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

            var point1 = new Point { X = -1, Y = -3 };
            var point2 = new Point { X = -1, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            var point4 = new Point { X = 5, Y = -3 };
            var expectedEntity = new Rectangle { A = point1, B = point2, C = point3, D = point4 };

            Assert.Equal(expectedOutput, _outputSb.ToString());
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public void Should_create_ring_correctly()
        {
            _inputs = new[] { "4", "1", "3", "5", "1" };
            var creator = CreateEntitiesCreator();
            var entity = creator.CreateEntity();

            string expectedOutput = string.Join(null,
                "\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
                "Введите параметры фигуры Кольцо",
                "Введите координаты центра:",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Введите радиус большего круга:",
                "Введите радиус меньшего круга:");

            var point = new Point { X = 1, Y = 3 };
            var expectedEntity = new Ring { Center = point, BigCircleRadius = 5, SmallCircleRadius = 1 };

            Assert.Equal(expectedOutput, _outputSb.ToString());
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [Fact]
        public void Should_create_triangle_correctly()
        {
            _inputs = new[] { "5", "1", "3", "1", "1", "5", "1" };
            var creator = CreateEntitiesCreator();
            var entity = creator.CreateEntity();

            string expectedOutput = string.Join(null,
                "\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка",
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

            var point1 = new Point { X = 1, Y = 3 };
            var point2 = new Point { X = 1, Y = 1 };
            var point3 = new Point { X = 5, Y = 1 };
            var expectedEntity = new Triangle { A = point1, B = point2, C = point3 };

            Assert.Equal(expectedOutput, _outputSb.ToString());
            entity.Should().BeEquivalentTo(expectedEntity);
        }
        private EntitiesCreator CreateEntitiesCreator()
        {
            var interactor = new Mock<IUserInteractor>();

            interactor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => _outputSb.Append(message));

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

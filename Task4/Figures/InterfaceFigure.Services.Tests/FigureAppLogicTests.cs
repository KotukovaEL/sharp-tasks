using Figures.ConsoleApp;
using Figures.Model;
using Figures.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InterfaceFigure.Services.Tests
{
    public class FigureAppLogicTests
    {
        private readonly StringBuilder _outputSb;
        private readonly List<GeometricEntity> _geometries;

        public FigureAppLogicTests()
        {
            _outputSb = new StringBuilder();
            _geometries = new List<GeometricEntity>();
        }

        [Fact]
        public void Should_process_Run_correctly()
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
                .Returns(string.Empty);

            var geometricEntitiesRepository = new Mock<IGeometricEntitiesRepository>();

            geometricEntitiesRepository
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity geometricEntity) =>
                {
                    _geometries.Add(geometricEntity);
                });

            geometricEntitiesRepository
                .Setup(x => x.List())
                .Returns(new List<GeometricEntity>() { });

            geometricEntitiesRepository
                .Setup(x => x.DeleteAll())
                .Callback(() =>
                {
                    _geometries.Clear();
                });

            var entitiesCreator = new Mock<IEntitiesCreator>();

            entitiesCreator
                .Setup(x => x.CreateEntityByType(It.IsAny<GeometricEntityTypes>()))
                .Returns(new Point(2, 2));

            var logic = new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
            logic.Run();

            string expectedOutput = string.Join(Environment.NewLine,
                "Выберите действие: ",
                "1. Добавить фигуру",
                "2. Вывести фигуры",
                "3. Очистить холст",
                "4. Выход",
                "Выберите тип фигуры: ",
                "1. Круг",
                "2. Линия",
                "3. Прямоугольник",
                "4. Кольцо",
                "5. Треугольник",
                "6. Точка",
                "Введите координаты X:",
                "Введите координаты Y:",
                "Фигура Point создана!");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }
    }
}

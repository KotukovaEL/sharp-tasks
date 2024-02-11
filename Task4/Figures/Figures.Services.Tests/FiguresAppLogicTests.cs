using Figures.ConsoleApp;
using Figures.Model;
using Figures.Repositories;
using Figures.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Figures.Services.Tests
{
    public class FiguresAppLogicTests
    {
        private readonly StringBuilder _outputSb;
        private readonly List<GeometricEntity> _entities;
        private string[] _inputs;
        private int _inputIndex;

        public FiguresAppLogicTests()
        {
            _outputSb = new StringBuilder();
            _entities = new List<GeometricEntity>();
            _inputIndex = 0;
        }

       
        [Fact]
        public void Should_add_figure_correctly()
        {
            _inputs = new[] {"1", "4",};

            var logic = CreateLogic(() => new Point(2, 2));
            logic.Run();

            string expectedOutput = string.Join(null,
                "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход",
                "Фигура Point создана!",
                "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_list_figure_correctly()
        {
            _inputs = new[] { "2", "4", };
            _entities.Add(new Point(2, 2));
            var logic = CreateLogic(() => new Point(2, 2));
            logic.Run();

            string expectedOutput = string.Join(null,
                "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход",
                "Точка: координаты: '2','2'.",
                "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_clear_figure_correctly()
        {
            _inputs = new[] { "3", "4", };

            var logic = CreateLogic(() => new Point(2, 2));
            logic.Run();

            string expectedOutput = string.Join(null,
                "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход",
                "",
                "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_print_error_message_incorrectly()
        {
            _inputs = new[] { "5", "4", };

            var logic = CreateLogic(() => new Point(2, 2));
            logic.Run();

            string expectedOutput = string.Join(null,
               "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход",
               "Попытайся заново",
               "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_add_figure_incorrectly()
        {
            _inputs = new[] { "1", "4", };

            var logic = CreateLogic(() => throw new ArgumentException("There is no such figure."));
            logic.Run();

            string expectedOutput = string.Join(null,
               "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход",
               "Произошла ошибка There is no such figure..",
               "Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        private FiguresAppLogic CreateLogic(Func<GeometricEntity> creatorFunc)
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

            var geometricEntitiesRepository = new Mock<IGeometricEntitiesRepository>();

            geometricEntitiesRepository
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity geometricEntity) =>
                {
                    _entities.Add(geometricEntity);
                });

            geometricEntitiesRepository
                .Setup(x => x.List())
                .Returns(_entities);

            geometricEntitiesRepository
                .Setup(x => x.DeleteAll())
                .Callback(() =>
                {
                    _entities.Clear();
                });

            var entitiesCreator = new Mock<IEntitiesCreator>();

            entitiesCreator
                .Setup(x => x.CreateEntity())
                .Returns(creatorFunc);

            return new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
        }
    }
}

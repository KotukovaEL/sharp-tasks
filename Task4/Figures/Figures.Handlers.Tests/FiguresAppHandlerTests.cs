using Figures.Common.Interfaces;
using Figures.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Figures.Handlers.Tests
{
    public class FiguresAppHandlerTests
    {
        private readonly StringBuilder _outputSb;
        private readonly List<GeometricEntity> _entities;
        private bool _calledAddFigure = false;
        private bool _calledDeleteFigures = false;
        private bool _calledAuthorize = false;
        private string[] _inputs;
        private int _inputIndex;

        public FiguresAppHandlerTests()
        {
            _outputSb = new StringBuilder();
            _entities = new List<GeometricEntity>();
            _inputIndex = 0;
        }


        [Fact]
        public void Should_add_figure_correctly()
        {
            _inputs = new[] { "Name", "1", "5" };

            var logic = CreateHandler(() => new Point { X = 2, Y = 2 });
            logic.Run();

            string expectedOutput = string.Join(null,
                "Введите имя пользователя: ",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход",
                "Name, выберите тип фигуры: ",
                "Фигура Point создана!",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_list_figure_correctly()
        {
            _inputs = new[] { "Name", "2", "5", };
            _entities.Add(new Point { X = 2, Y = 2 });
            var logic = CreateHandler(() => new Point { X = 2, Y = 2 });
            logic.Run();

            string expectedOutput = string.Join(null,
                "Введите имя пользователя: ",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход",
                "Список фигур пользователя Name",
                "Id точки: 0. Точка: координаты: '2','2'.",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход");
            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_clear_figure_correctly()
        {
            _inputs = new[] { "Name", "3", "2", "5", };

            var logic = CreateHandler(() => new Point { X = 2, Y = 2 });
            logic.Run();

            string expectedOutput = string.Join(null,
                "Введите имя пользователя: ",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход",
                "Список фигур пользователя Name",
                "Список Пуст",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_print_error_message_incorrectly()
        {
            _inputs = new[] {"Name", "6", "5" };

            var logic = CreateHandler(() => new Point { X = 2, Y = 2 });
            logic.Run();

            string expectedOutput = string.Join(null,
                "Введите имя пользователя: ",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход",
                "Попытайся заново",
                "Name, выберите действие: ",
                "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_add_figure_incorrectly()
        {
            _inputs = new[] { "Name", "1", "5" };

            var logic = CreateHandler(() => throw new ArgumentException("There is no such figure."));
            logic.Run();

            string expectedOutput = string.Join(null,
               "Введите имя пользователя: ",
               "Name, выберите действие: ",
               "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход",
               "Name, выберите тип фигуры: ",
               "Произошла ошибка There is no such figure..",
               "Name, выберите действие: ",
               "\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        private FiguresAppHandler CreateHandler(Func<GeometricEntity> creatorFunc)
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

            var geometricEntitiesRepository = new Mock<IGeometricEntitiesRepository>();

            geometricEntitiesRepository
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity geometricEntity) => _entities.Add(geometricEntity));

            geometricEntitiesRepository
                .Setup(x => x.List())
                .Returns(_entities);

            geometricEntitiesRepository
                .Setup(x => x.DeleteFiguresByIds(It.IsAny<List<int>>()))
                .Callback(() => _entities.Clear());

            var entitiesCreator = new Mock<IEntitiesCreator>();

            entitiesCreator
                .Setup(x => x.CreateEntity())
                .Returns(creatorFunc);

            var usersService = new Mock<IUsersService>();

            usersService
                .Setup(x => x.AddFigure(It.IsAny<string>(), It.IsAny<GeometricEntity>()))
                .Callback((string name, GeometricEntity geometricEntity) => _calledAddFigure = true);

            usersService
                .Setup(x => x.ListFigures(It.IsAny<string>()))
                .Returns(_entities);

            usersService
                .Setup(x => x.DeleteFigures(It.IsAny<string>()))
                .Callback(() => _calledDeleteFigures = true);

            usersService
                .Setup(x => x.Authorize(It.IsAny<string>()))
                .Callback(() => _calledAuthorize = true);

            return new FiguresAppHandler(interactor.Object, entitiesCreator.Object, usersService.Object);
        }
    }
}

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
        public void Should_add_figure_correctly()
        {
            var inputs = new string[]
            {
                "1",
                "4",
            };
            var inputIndex = 0;

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
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

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
                .Setup(x => x.CreateEntity())
                .Returns(new Point(2, 2));

            var logic = new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
            logic.Run();

            string expectedOutput = string.Join(null,
                "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����",
                "������ Point �������!",
                "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_list_figure_correctly()
        {
            var inputs = new string[]
            {
                "2",
                "4",
            };
            var inputIndex = 0;

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
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

            var geometricEntitiesRepository = new Mock<IGeometricEntitiesRepository>();

            geometricEntitiesRepository
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity geometricEntity) =>
                {
                    _geometries.Add(geometricEntity);
                });

            geometricEntitiesRepository
                .Setup(x => x.List())
                .Returns(new List<GeometricEntity>() {new Point(2,2)});

            geometricEntitiesRepository
                .Setup(x => x.DeleteAll())
                .Callback(() =>
                {
                    _geometries.Clear();
                });

            var entitiesCreator = new Mock<IEntitiesCreator>();

            entitiesCreator
                .Setup(x => x.CreateEntity())
                .Returns(new Point(2, 2));

            var logic = new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
            logic.Run();

            string expectedOutput = string.Join(null,
                "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����",
                "�����: ����������: '2','2'.",
                "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_clear_figure_correctly()
        {
            var inputs = new string[]
            {
                "3",
                "4",
            };
            var inputIndex = 0;

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
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

            var geometricEntitiesRepository = new Mock<IGeometricEntitiesRepository>();

            geometricEntitiesRepository
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity geometricEntity) =>
                {
                    _geometries.Add(geometricEntity);
                });

            geometricEntitiesRepository
                .Setup(x => x.List())
                .Returns(new List<GeometricEntity>() { new Point(2, 2) });

            geometricEntitiesRepository
                .Setup(x => x.DeleteAll())
                .Callback(() =>
                {
                    _geometries.Clear();
                });

            var entitiesCreator = new Mock<IEntitiesCreator>();

            entitiesCreator
                .Setup(x => x.CreateEntity())
                .Returns(new Point(2, 2));

            var logic = new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
            logic.Run();

            string expectedOutput = string.Join(null,
                "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����",
                "",
                "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_print_error_message_incorrectly()
        {
            var inputs = new string[]
            {
                "5",
                "4",
            };
            var inputIndex = 0;

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
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

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
                .Setup(x => x.CreateEntity())
                .Returns(new Point(2, 2));

            var logic = new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
            logic.Run();

            string expectedOutput = string.Join(null,
               "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����",
               "��������� ������",
               "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }

        [Fact]
        public void Should_add_figure_incorrectly()
        {
            var inputs = new string[]
            {
                "1",
                "4",
            };
            var inputIndex = 0;

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
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

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
                .Setup(x => x.CreateEntity())
                .Returns(() => throw new ArgumentException("There is no such figure."));

            var logic = new FiguresAppLogic(interactor.Object, geometricEntitiesRepository.Object, entitiesCreator.Object);
            logic.Run();

            string expectedOutput = string.Join(null,
               "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����",
               "��������� ������ There is no such figure..",
               "�������� ��������:\n\t1. �������� ������\n\t2. ������� ������\n\t3. �������� �����\n\t4. �����");

            Assert.Equal(expectedOutput, _outputSb.ToString());
        }
    }
}

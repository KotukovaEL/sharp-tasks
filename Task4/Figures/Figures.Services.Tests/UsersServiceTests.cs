using Figures.Common.Interfaces;
using Figures.Model;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Figures.Services.Tests
{
    public class UsersServiceTests
    {
        [Fact]
        public void Should_add_figure_correctly()
        {
            var userFromRepo = new User { Name = "Name" };
            GeometricEntity? entityFromRepo = null;
            var calledAddFigure = false;

            var entitiesRepo = new Mock<IGeometricEntitiesRepository>();
            entitiesRepo
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity entity) => entityFromRepo = entity);

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.AddFigure(It.IsAny<string>(), It.IsAny<int>()))
                .Callback(() => calledAddFigure = true);

            var usersService = new UsersService(entitiesRepo.Object, usersRepo.Object);
            var point = new Point { X = 6, Y = 8, Id = 1 };

            usersService.AddFigure("Name", point);
            entityFromRepo.Should().BeEquivalentTo(point);
            Assert.True(calledAddFigure);
        }

        [Fact]
        public void Should_list_figures()
        {
            var userFromRepo = new User { Name = "Name" };
            userFromRepo.EntityIdList.AddRange(new int[] { 2, 4 });

            var entitiesFromRepo = new List<GeometricEntity>()
            {
                new Point { X = 6, Y = 8, Id = 1 },
                new Circle { Center = new Point { X = 5, Y = 4, Id = 1 }, Radius = 8, Id = 2 },
                new LineSegment { A = new Point { X = 9, Y = 11 }, B = new Point { X = 10, Y = 11 }, Id = 3 },
                new Point { X = 12, Y = 12, Id = 4 },
            };

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns(userFromRepo);

            var entityRepo = new Mock<IGeometricEntitiesRepository>();
            entityRepo
                .Setup(x => x.GetEntityById(It.IsAny<int>()))
                .Returns((int entityId) => entitiesFromRepo.Single(x => x.Id == entityId));

            var usersService = new UsersService(entityRepo.Object, usersRepo.Object);
            var results = usersService.ListFigures("Name");

            var expectedResults = new List<GeometricEntity>()
            {
                new Circle { Center = new Point { X = 5, Y = 4, Id = 1 }, Radius = 8, Id = 2 },
                new Point { X = 12, Y = 12, Id = 4 },
            };

            results.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_delete_figures_correctly()
        {
            var calledDelete = false;
            var userFromRepo = new User { Name = "Name" };
            userFromRepo.EntityIdList.AddRange(new[] { 1, 2, 3, 4 });

            var entitiesFromRepo = new List<GeometricEntity>()
            {
                new Point { X = 6, Y = 8, Id = 1 },
                new Circle { Center = new Point { X = 5, Y = 4 }, Radius = 8, Id = 2 },
                new LineSegment { A = new Point { X = 9, Y = 11 }, B = new Point { X = 10, Y = 11 }, Id = 3 },
                new Point { X = 12, Y = 12, Id = 4 },
            };

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns(userFromRepo);

            var entityRepo = new Mock<IGeometricEntitiesRepository>();
            entityRepo
                .Setup(x => x.DeleteFiguresByIds(It.IsAny<List<int>>()))
                .Callback(() => calledDelete = true);

            var usersService = new UsersService(entityRepo.Object, usersRepo.Object);
            usersService.DeleteFigures("Name");
            Assert.Empty(userFromRepo.EntityIdList);
            Assert.True(calledDelete);
        }

        [Fact]
        public void Should_authorize_correctly()
        {
            var calledUsersTryAdd = false;

            var entityRepo = new Mock<IGeometricEntitiesRepository>();

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.TryAdd(It.IsAny<string>()))
                .Callback((string name) => calledUsersTryAdd = true);

            var usersService = new UsersService(entityRepo.Object, usersRepo.Object);

            usersService.Authorize("Name");
            Assert.True(calledUsersTryAdd);
        }
    }
}

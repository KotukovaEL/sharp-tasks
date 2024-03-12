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
            var userFromRepo = new User("Name");
            GeometricEntity? entityFromRepo = null;
            var entitiesRepo = new Mock<IGeometricEntitiesRepository>();
            entitiesRepo
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity entity) => { entityFromRepo = entity; });

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns((string name) => { return userFromRepo; });

            var usersService = new UsersService(entitiesRepo.Object, usersRepo.Object);
            var point = new Point(6, 8);
            point.Id = 1;

            usersService.AddFigure("Name", point);
            entityFromRepo.Should().BeEquivalentTo(point);
            Assert.True(userFromRepo.EntityIdList.Single() == point.Id);            
        }

        [Fact]
        public void Should_list_figures()
        {
            var userFromRepo = new User("Name");
            userFromRepo.EntityIdList.AddRange(new int[] { 2, 4 });

            var entitiesFromRepo = new List<GeometricEntity>() 
            { 
                new Point(6, 8) { Id = 1 },
                new Circle(new Point(5, 4), 8) { Id = 2 },
                new LineSegment(new Point(9, 11), new Point(10, 11)) { Id = 3 },
                new Point(12, 12) { Id = 4 },
            }; 

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns((string name) => { return userFromRepo; });

            var entityRepo = new Mock<IGeometricEntitiesRepository>();
            entityRepo
                .Setup(x => x.GetEntityById(It.IsAny<int>()))
                .Returns((int entityId) => { return entitiesFromRepo.Single(x => x.Id == entityId); });

            var usersService = new UsersService(entityRepo.Object, usersRepo.Object);
            var results = usersService.ListFigures("Name");
            
            var expectedResults = new List<GeometricEntity>()
            {
                new Circle(new Point(5, 4), 8) { Id = 2 },
                new Point(12, 12) { Id = 4 },
            };

            results.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_delete_figures_correctly()
        {
            var calledDelete = false;

            var userFromRepo = new User("Name");
            userFromRepo.EntityIdList.AddRange(new[] { 1, 2, 3, 4 });

            var entitiesFromRepo = new List<GeometricEntity>()
            {
                new Point(6, 8) { Id = 1 },
                new Circle(new Point(5, 4), 8) { Id = 2 },
                new LineSegment(new Point(9, 11), new Point(10, 11)) { Id = 3 },
                new Point(12, 12) { Id = 4 },
            };

            var usersRepo = new Mock<IUsersRepository>();
            usersRepo
                .Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns((string name) => { return userFromRepo; });

            var entityRepo = new Mock<IGeometricEntitiesRepository>();
            entityRepo
                .Setup(x => x.DeleteFiguresByIds(It.IsAny<List<int>>()))
                .Callback(() => { calledDelete = true; });

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
                .Callback((string name) => { calledUsersTryAdd = true; });

            var usersService = new UsersService(entityRepo.Object, usersRepo.Object);

            usersService.Authorize("Name");
            
            Assert.True(calledUsersTryAdd);

        }
    }
}

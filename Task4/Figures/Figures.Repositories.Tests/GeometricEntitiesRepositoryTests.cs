using Moq;
using Xunit;
using Figures.Common.Interfaces;
using Newtonsoft.Json.Linq;
using Figures.Model;
using Figures.Repositories;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentAssertions;

namespace Figures.Services.Tests
{
    public class GeometricEntitiesRepositoryTests
    {
        [Fact]
        public void Should_list_entities_correctly()
        {
            var context = new Mock<ITxtDbContext<int, GeometricEntity>>();
            context
                .Setup(x => x.EntitiesMap)
                .Returns(new Dictionary<int, GeometricEntity>
                {
                    { 1, new Point(6, 8) { Id = 1 } },
                    { 4, new Point(12, 12) { Id = 4 } },
                }) ;

            var repo = new GeometricEntitiesRepository(context.Object);
            var results = repo.List();

            var expectedResults = new List<GeometricEntity>()
            {
                new Point(6, 8) { Id = 1 },
                new Point(12, 12) { Id = 4 },
            };

            results.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_get_entity_by_id_correctly()
        {
            var point = new Point(6, 8) { Id = 1};

            var context = new Mock<ITxtDbContext<int, GeometricEntity>>();
            context
                .Setup(x => x.GetByKey(It.IsAny<int>()))
                .Returns((int entityId) => point);

            var entitiesRepository = new GeometricEntitiesRepository(context.Object);
            var result = entitiesRepository.GetEntityById(point.Id);
            result.Should().BeEquivalentTo(point);
        }

        [Fact]
        public void Should_add_correctly()
        {
            GeometricEntity? entityFromRepo = null;

            var context = new Mock<ITxtDbContext<int, GeometricEntity>>();
            context
                .Setup(x => x.Add(It.IsAny<GeometricEntity>()))
                .Callback((GeometricEntity entity) => { entityFromRepo = entity; });

            var entitiesRepository = new GeometricEntitiesRepository(context.Object);
            var point = new Point(6, 8) { Id = 1 };
            entitiesRepository.Add(point);
            entityFromRepo.Should().BeEquivalentTo(point);
        }

        [Fact]
        public void Should_delete_figures_by_ids_correctly()
        {
            var calledSaveChanges = false;
            var context = new Mock<ITxtDbContext<int, GeometricEntity>>();
            context
                .Setup(x => x.EntitiesMap)
                .Returns(new Dictionary<int, GeometricEntity>
                {
                    { 1, new Point(6, 8) { Id = 1 } },
                    { 4, new Point(12, 12) { Id = 4 } },
                    { 5, new Point(11, 11) { Id = 5 } },
                });

            context
                .Setup(x => x.SaveChanges())
                .Callback(() => calledSaveChanges = true);

            var repo = new GeometricEntitiesRepository(context.Object);
            repo.DeleteFiguresByIds(new List<int>() {1, 4 });

            var results = repo.List();

            var expectedResults = new List<GeometricEntity>()
            {
                 new Point(11, 11) { Id = 5 }
            };

            results.Should().BeEquivalentTo(expectedResults);
            Assert.True(calledSaveChanges);
        }
    }
}

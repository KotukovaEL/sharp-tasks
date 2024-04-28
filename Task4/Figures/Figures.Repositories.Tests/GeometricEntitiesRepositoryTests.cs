using Moq;
using Xunit;
using Figures.Common.Interfaces;
using Newtonsoft.Json.Linq;
using Figures.Model;
using Figures.Repositories;
using System.Collections.Generic;
using FluentAssertions;
using Figures.Repositories.Interface;

namespace Figures.Services.Tests
{
    public class GeometricEntitiesRepositoryTests
    {
        [Fact]
        public void Should_list_entities_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity> 
            { 
                { 1, new Point { X = 6, Y = 8, Id = 1 } },
                { 4, new Point { X = 12, Y = 12, Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var writer = new Mock<IGeometricEntitiesWriter>();

            var reader = new Mock<IGeometricEntitiesReader>();
            reader
                .Setup(x => x.ReadFile())
                .Returns(() => context);

            var repo = new GeometricEntitiesRepository(writer.Object, reader.Object);
            var results = repo.List();

            var expectedResults = new List<GeometricEntity>()
            {
                new Point { X = 6, Y = 8, Id = 1 },
                new Point { X = 12, Y = 12, Id = 4 },
            };

            results.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_get_entity_by_id_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity> {{ 1, new Point { X = 6, Y = 8, Id = 1 } }};
            var context = new GeometricEntitiesContext(entitiesMap);

            var writer = new Mock<IGeometricEntitiesWriter>();

            var reader = new Mock<IGeometricEntitiesReader>();
            reader
                .Setup(x => x.ReadFile())
                .Returns(() => context);

            var repo = new GeometricEntitiesRepository(writer.Object, reader.Object);
            var result = repo.GetEntityById(1);
            var expectedResult = new Point { X = 6, Y = 8, Id = 1 };
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Should_add_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity> { };
            var context = new GeometricEntitiesContext(entitiesMap);
            var calledSaveChanges = false;

            var writer = new Mock<IGeometricEntitiesWriter>();
            writer
                .Setup(x => x.SaveChanges(It.IsAny<GeometricEntitiesContext>()))
                .Callback(() => calledSaveChanges = true);

            var reader = new Mock<IGeometricEntitiesReader>();
            reader
                .Setup(x => x.ReadFile())
                .Returns(() => context);

            var repo = new GeometricEntitiesRepository(writer.Object, reader.Object);
            var point = new Point { X = 6, Y = 8, Id = 1 };
            repo.Add(point);
            var expectedResult = context.GetByKey(point.Id);
            point.Should().BeEquivalentTo(expectedResult);
            Assert.True(calledSaveChanges);
        }

        [Fact]
        public void Should_delete_figures_by_ids_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point { X = 6, Y = 8, Id = 1 } },
                { 4, new Point { X = 12, Y = 12, Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);
            var calledSaveChanges = false;

            var writer = new Mock<IGeometricEntitiesWriter>();
            writer
                .Setup(x => x.SaveChanges(It.IsAny<GeometricEntitiesContext>()))
                .Callback(() => calledSaveChanges = true);

            var reader = new Mock<IGeometricEntitiesReader>();
            reader
                .Setup(x => x.ReadFile())
                .Returns(() => context);

            var repo = new GeometricEntitiesRepository(writer.Object, reader.Object);
            repo.DeleteFiguresByIds(new List<int>() {4 });
            var results = repo.List();
            var expectedResults = new List<GeometricEntity>()
            {
                new Point { X = 6, Y = 8, Id = 1 }
            };

            Assert.True(calledSaveChanges);
            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

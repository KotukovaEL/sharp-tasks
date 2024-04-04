using Figures.Model;
using Figures.Repositories.Interface;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests
{
    public class GeometricEntitiesContextTests
    {
        [Fact]
        public void Should_get_by_key_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point(6, 8) { Id = 1 } },
                { 4, new Point(12, 12) { Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);
            var entity = context.GetByKey(1);
            var expectedResults = new Point(6, 8) { Id = 1 };
            entity.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_list_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point(6, 8) { Id = 1 } },
                { 4, new Point(12, 12) { Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);
            var geometricEntities = context.List();

            var expectedResults = new List<GeometricEntity> 
            {
                { new Point(6, 8) { Id = 1 } },
                { new Point(12, 12) { Id = 4 } },
            };

            geometricEntities.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_add_geometric_entity_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
            };

            var context = new GeometricEntitiesContext(entitiesMap);
            var point = new Point(2, 5) { Id = 1 };
            context.Add(point);

            var geometricEntities = context.List();
            var expectedResults = new List<GeometricEntity>
            {
                { new Point(2, 5) { Id = 1 } },
            };

            geometricEntities.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_remove_geometric_entity_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point(6, 8) { Id = 1 } },
                { 4, new Point(12, 12) { Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);
            context.Remove(4);

            var geometricEntities = context.List();
            var expectedResults = new List<GeometricEntity>
            {
                { new Point(6, 8) { Id = 1 } },
            };

            geometricEntities.Should().BeEquivalentTo(expectedResults);
        }
    }
}

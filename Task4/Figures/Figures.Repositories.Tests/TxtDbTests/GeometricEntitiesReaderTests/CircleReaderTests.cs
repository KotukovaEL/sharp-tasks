using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.TxtDbTests.GeometricEntitiesReaderTests
{
    public class CircleReaderTests
    {
        [Fact]
        public void Should_read_data_for_circle_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point { X = 2, Y = 3, Id = 2 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var fieldsMap = new Dictionary<string, string>
            {
                { "Center", "2"},
                { "Radius", "3"},
                { "Id", "1"},
            };

            var circleReader = new CircleReader();
            var results = circleReader.Read(fieldsMap, context);
            var expectedResults = new Circle
            {
                Center = new Point { X = 2, Y = 3, Id = 2 },
                Radius = 3,
                Id = 1
            };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

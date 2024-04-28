using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.TxtDbTests.GeometricEntitiesReaderTests
{
    public class RingReaderTests
    {
        [Fact]
        public void Should_read_data_for_ring_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point { X = 2, Y = 3, Id = 2 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var fieldsMap = new Dictionary<string, string>
            {
                { "Center", "2"},
                { "Long radius", "3"},
                { "Short radius", "2"},
                { "Id", "1"},
            };

            var ringReader = new RingReader();
            var results = ringReader.Read(fieldsMap, context);
            var expectedResults = new Ring
            {
                Center = new Point { X = 2, Y = 3, Id = 2 },
                BigCircleRadius = 3,
                SmallCircleRadius = 2,
                Id = 1
            };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

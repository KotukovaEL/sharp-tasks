using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesReaderTests
{
    public class RingReaderTests
    {
        [Fact]
        public void Should_read_data_for_ring_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point(2, 3) {Id = 2 } },
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
            var expectedResults = new Ring(
                new Point(2, 3) { Id = 2 },
                3, 
                2) 
            { Id = 1 };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

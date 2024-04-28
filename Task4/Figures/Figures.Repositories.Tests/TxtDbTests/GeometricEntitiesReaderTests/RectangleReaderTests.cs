using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.TxtDbTests.GeometricEntitiesReaderTests
{
    public class RectangleReaderTests
    {
        [Fact]
        public void Should_read_data_for_rectangle_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point { X = 1, Y = 1, Id = 2 } },
                { 3, new Point { X = 1, Y = 3, Id = 3 } },
                { 4, new Point { X = 4, Y = 3, Id = 4 } },
                { 5, new Point { X = 4, Y = 1, Id = 5 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var fieldsMap = new Dictionary<string, string>
            {
                { "A", "2"},
                { "B", "3"},
                { "C", "4"},
                { "D", "5"},
                { "Id", "1"},
            };

            var rectangleReader = new RectangleReader();
            var results = rectangleReader.Read(fieldsMap, context);
            var expectedResults = new Rectangle
            {
                A = new Point { X = 1, Y = 1, Id = 2 },
                B = new Point { X = 1, Y = 3, Id = 3 },
                C = new Point { X = 4, Y = 3, Id = 4 },
                D = new Point { X = 4, Y = 1, Id = 5 },
                Id = 1
            };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

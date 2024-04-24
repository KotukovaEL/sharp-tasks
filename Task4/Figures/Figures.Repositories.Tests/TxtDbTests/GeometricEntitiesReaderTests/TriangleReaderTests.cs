using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.TxtDbTests.GeometricEntitiesReaderTests
{
    public class TriangleReaderTests
    {
        [Fact]
        public void Should_read_data_for_triangle_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point { X = 1, Y = 1, Id = 2 } },
                { 3, new Point { X = 1, Y = 3, Id = 3 } },
                { 4, new Point { X = 4, Y = 3, Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var fieldsMap = new Dictionary<string, string>
            {
                { "A", "2"},
                { "B", "3"},
                { "C", "4"},
                { "Id", "1"},
            };

            var triangleReader = new TriangleReader();
            var results = triangleReader.Read(fieldsMap, context);
            var expectedResults = new Triangle
            {
                A = new Point { X = 1, Y = 1, Id = 2 },
                B = new Point { X = 1, Y = 3, Id = 3 },
                C = new Point { X = 4, Y = 3, Id = 4 },
                Id = 1
            };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

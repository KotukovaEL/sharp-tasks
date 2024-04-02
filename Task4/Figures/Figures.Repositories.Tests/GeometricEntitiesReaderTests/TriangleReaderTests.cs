using Figures.Model;
using Figures.Repositories.Readers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesReaderTests
{
    public class TriangleReaderTests
    {
        [Fact]
        public void Should_read_data_for_triangle_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point(1, 1) {Id = 2 } },
                { 3, new Point(1, 3) {Id = 3 } },
                { 4, new Point(4, 3) {Id = 4 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var map = new Dictionary<string, string>
            {
                { "A", "2"},
                { "B", "3"},
                { "C", "4"},
                { "Id", "1"},
            };

            var triangleReader = new TriangleReader();
            var results = triangleReader.Read(map, context);
            var expectedResults = new Triangle(new Point(1, 1) { Id = 2 }, new Point(1, 3) { Id = 3 }, new Point(4, 3) { Id = 4 }) { Id = 1 };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

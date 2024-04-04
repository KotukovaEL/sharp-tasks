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
    public class LineSegmentReaderTests
    {
        [Fact]
        public void Should_read_data_for_line_segment_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point(2, 3) {Id = 2 } },
                { 3, new Point(3, 3) {Id = 3 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var fieldsMap = new Dictionary<string, string>
            {
                { "A", "2"},
                { "B", "3"},
                { "Id", "1"},
            };

            var lineSegmentReader = new LineSegmentReader();
            var results = lineSegmentReader.Read(fieldsMap, context);
            var expectedResults = new LineSegment(
                new Point(2, 3) { Id = 2 }, 
                new Point(3, 3) { Id = 3 }) 
            { Id = 1 };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesReaderTests
{
    public class PointReaderTests
    {
        [Fact]
        public void Should_read_data_for_point_correctly()
        {
            var context = new GeometricEntitiesContext();

            var fieldsMap = new Dictionary<string, string>
            {
                { "X", "2"},
                { "Y", "3"},
                { "Id", "1"},
            };

            var pointReader = new PointReader();
            var results = pointReader.Read(fieldsMap, context);
            var expectedResults = new Point { X = 2, Y = 3, Id = 1 };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

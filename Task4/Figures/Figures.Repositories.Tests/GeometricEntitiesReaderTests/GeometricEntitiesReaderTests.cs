using Figures.Model;
using Figures.Repositories.Readers;
using Figures.Repositories.Writers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesReaderTests
{
    public class GeometricEntitiesReaderTests
    {
        [Fact]
        public void Should_read_correctly()
        { 
            var lines = new string[] 
            {
                "Id: 1",
                "X: 7",
                "Y: 8",
                "Point",
                "",
            };

            var readersMap = new Dictionary<string, IEntityReader<GeometricEntity>>()
            {
                { "Point", new EntityReader<Point>(new PointReader()) }
            };

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(lines);

            var geometricEntitiesReader = new GeometricEntitiesReader(sourceIO.Object, readersMap);
            var results = geometricEntitiesReader.ReadFile();
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                {1, new Point(7, 8) { Id = 1 } },
            };
            var expectedResults = new GeometricEntitiesContext(entitiesMap);
            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

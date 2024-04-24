using Figures.Model;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Figures.Repositories.Tests.JsonDbTests
{
    public class GeometricEntitiesReaderTests
    {
        [Fact]
        public void Should_read_correctly()
        {
            var jsonStr = "{\r\n  \"Points\": [\r\n    {\r\n      \"X\": 4,\r\n      \"Y\": 5,\r\n      \"Id\": 1\r\n    },\r\n    {\r\n      \"X\": 4,\r\n      \"Y\": 7,\r\n      \"Id\": 2\r\n    }\r\n  ],\r\n  \"LineSegments\": [],\r\n  \"Circles\": [],\r\n  \"Rectangles\": [],\r\n  \"Triangles\": [],\r\n  \"Rings\": []\r\n}";

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.ReadAllText())
                .Returns(jsonStr);

            var geometricEntitiesReader = new JsonDb.GeometricEntitiesReader(sourceIO.Object);
            var results = geometricEntitiesReader.ReadFile();
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                {1, new Point { X = 4, Y = 5, Id = 1 } },
            };
            var expectedResults = new GeometricEntitiesContext(entitiesMap);
            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

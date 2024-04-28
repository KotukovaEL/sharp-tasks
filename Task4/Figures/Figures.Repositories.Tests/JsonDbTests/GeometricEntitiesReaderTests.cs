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
            var jsonStr = @"
{
  ""Points"": [
    {
      ""X"": 4,
      ""Y"": 5,
      ""Id"": 1
    }
  ],
  ""LineSegments"": [],
  ""Circles"": [],
  ""Rectangles"": [],
  ""Triangles"": [],
  ""Rings"": []
}";


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

using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.JsonDbTests
{
    public class GeometricEntitiesWriterTests
    {
        [Fact]
        public void Should_save_changes_correctly()
        {
            var calledWriteAllText = false;
            var jsonStr = "{\r\n  \"Points\": [\r\n    {\r\n      \"X\": 4,\r\n      \"Y\": 5,\r\n      \"Id\": 1\r\n    }\r\n  ],\r\n  \"LineSegments\": [],\r\n  \"Circles\": [],\r\n  \"Rectangles\": [],\r\n  \"Triangles\": [],\r\n  \"Rings\": []\r\n}";
            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.WriteAllText(jsonStr))
                .Callback(() => calledWriteAllText = true);

            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                {1, new Point { X = 4, Y = 5, Id = 1 } },
            };
            
            var context = new GeometricEntitiesContext(entitiesMap);

            var geometricEntitiesWriter = new JsonDb.GeometricEntitiesWriter(sourceIO.Object);
            geometricEntitiesWriter.SaveChanges(context);
            var expectedResults = new GeometricEntitiesContext(entitiesMap);
            Assert.True(calledWriteAllText);
        }
    }
}

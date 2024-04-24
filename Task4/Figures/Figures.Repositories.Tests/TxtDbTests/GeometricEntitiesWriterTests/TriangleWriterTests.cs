using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
using Figures.Repositories.Writers;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.TxtDbTests.GeometricEntitiesWriterTests
{
    public class TriangleWriterTests
    {
        [Fact]
        public void Should_save_changes_for_triangle_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var txtWriter = new TestTextWriter(memoryStream);

            var calledPointWriter = false;

            var pointWriter = new Mock<IEntityWriter<Point>>();
            pointWriter
                .Setup(x => x.Save(It.IsAny<TextWriter>(), It.IsAny<Point>(), It.IsAny<IdGenerator>()))
                .Callback(() => calledPointWriter = true);

            var triangleWriter = new TriangleWriter(pointWriter.Object);
            var pointA = new Point { X = 1, Y = 1 };
            var pointB = new Point { X = 1, Y = 1 };
            var pointC = new Point { X = 4, Y = 4 };
            var triangle = new Triangle { A = pointA, B = pointB, C = pointC, Id = 1 };
            var idGenerator = new IdGenerator();
            idGenerator.Add(triangle.Id);

            triangleWriter.Save(txtWriter, triangle, idGenerator);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(memoryStream);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
                " Id: 1",
                " A: 2",
                " B: 3",
                " C: 4",
                "Triangle",
                "",
                "");

            Assert.Equal(expectedResults, results);
            Assert.True(calledPointWriter);
        }
    }
}

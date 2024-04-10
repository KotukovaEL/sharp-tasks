using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesWriterTests
{
    public class LineSegmentWriterTests
    {
        [Fact]
        public void Should_save_changes_for_line_segment_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var txtWriter = new TestTextWriter(memoryStream);

            var calledPointWriter = false;

            var pointWriter = new Mock<IEntityWriter<Point>>();
            pointWriter
                .Setup(x => x.Save(It.IsAny<TextWriter>(), It.IsAny<Point>(), It.IsAny<IdGenerator>()))
                .Callback(() => calledPointWriter = true);
            
            var lineSegmentWriter = new LineSegmentWriter(pointWriter.Object);
            var pointA = new Point(2, 2);
            var pointB = new Point(3, 3);
            var lineSegment = new LineSegment(pointA, pointB) { Id = 1 };
            var idGenerator = new IdGenerator();
            idGenerator.Add(lineSegment.Id);

            lineSegmentWriter.Save(txtWriter, lineSegment, idGenerator);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(memoryStream);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
                " Id: 1",
                " A: 2",
                " B: 3",
                "LineSegment",
                "",
                "");

            Assert.Equal(expectedResults, results);
            Assert.True(calledPointWriter);
        }
    }
}

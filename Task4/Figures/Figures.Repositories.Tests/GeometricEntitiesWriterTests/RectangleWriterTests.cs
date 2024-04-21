using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesWriterTests
{
    public class RectangleWriterTests
    {
        [Fact]
        public void Should_save_changes_for_rectangle_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var txtWriter = new TestTextWriter(memoryStream);

            var calledPointWriter = false;

            var pointWriter = new Mock<IEntityWriter<Point>>();
            pointWriter
                .Setup(x => x.Save(It.IsAny<TextWriter>(), It.IsAny<Point>(), It.IsAny<IdGenerator>()))
                .Callback(() => calledPointWriter = true);
            
            var rectangleWriter = new RectangleWriter(pointWriter.Object);
            var pointA = new Point { X = 1, Y = 1 };
            var pointB = new Point { X = 1, Y = 1 };
            var pointC = new Point { X = 4, Y = 4 };
            var pointD = new Point { X = 4, Y = 4 };
            var rectangle = new Rectangle { A = pointA, B = pointB, C = pointC, D = pointD, Id = 1 };
            var idGenerator = new IdGenerator();
            idGenerator.Add(rectangle.Id);

            rectangleWriter.Save(txtWriter, rectangle, idGenerator);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(memoryStream);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
                " Id: 1",
                " A: 2",
                " B: 3",
                " C: 4",
                " D: 5",
                "Rectangle",
                "",
                "");

            Assert.Equal(expectedResults, results);
            Assert.True(calledPointWriter);
        }
    }
}

using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesWriterTests
{
    public class RingWriterTests
    {
        [Fact]
        public void Should_save_changes_for_ring_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var txtWriter = new TestTextWriter(memoryStream);

            var calledPointWriter = false;

            var pointWriter = new Mock<IEntityWriter<Point>>();
            pointWriter
                .Setup(x => x.Save(It.IsAny<TextWriter>(), It.IsAny<Point>(), It.IsAny<IdGenerator>()))
                .Callback(() => calledPointWriter = true);
            
            var RingWriter = new RingWriter(pointWriter.Object);
            var center = new Point(2, 2);
            var bigRadius = 4;
            var shortRadius = 3;
            var ring = new Ring(center, bigRadius, shortRadius) { Id = 1 };
            var idGenerator = new IdGenerator();
            idGenerator.Add(ring.Id);

            RingWriter.Save(txtWriter, ring, idGenerator);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(memoryStream);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
                " Id: 1",
                " Center: 2",
                " Long radius: 4",
                " Short radius: 3",
                "Ring",
                "",
                "");

            Assert.Equal(expectedResults, results);
            Assert.True(calledPointWriter);
        }
    }
}

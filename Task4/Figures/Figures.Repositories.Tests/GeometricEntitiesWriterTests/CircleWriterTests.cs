using Figures.Model;
using Figures.Repositories.Interface;
using Figures.Repositories.Writers;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesWriterTests
{
    public class CircleWriterTests
    {
        [Fact]
        public void Should_save_changes_for_circle_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var txtWriter = new TestTextWriter(memoryStream);

            var calledPointWriter = false;

            var pointWriter = new Mock<IEntityWriter<Point>>();
            pointWriter
                .Setup(x => x.Save(It.IsAny<TextWriter>(), It.IsAny<Point>(), It.IsAny<IdGenerator>()))
                .Callback(() => calledPointWriter = true);
           var circleWriter = new CircleWriter(pointWriter.Object); 

            var center = new Point(2, 2);
            var circle = new Circle(center, 5) { Id = 1 };
            var idGenerator = new IdGenerator();
            idGenerator.Add(circle.Id);

            circleWriter.Save(txtWriter, circle, idGenerator);

            memoryStream.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(memoryStream);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
                " Id: 1",
                " Center: 2",
                " Radius: 5",
                "Circle",
                "",
                "");

            Assert.Equal(expectedResults, results);
            Assert.True(calledPointWriter);
        }
    }
}

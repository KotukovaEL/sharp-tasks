using Figures.Model;
using Moq;
using System;
using System.IO;
using Xunit;

namespace Figures.Repositories.Tests
{
    public class GeometricEntitiesTxtDbContextTests 
    {
        [Fact]
        public void Should_save_changes_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(new string[] {});

            var context = new GeometricEntitiesTxtDbContext(sourceIO.Object);

            var point = new Point(2, 2);
            point.Id = 1;
            context.Add(point);
            context.SaveChanges();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var results = new StreamReader(memoryStream).ReadToEnd();
            var expectedResults = string.Join(Environment.NewLine,
                " Id: 1",
                " X: 2",
                " Y: 2",
                "- Point",
                "",
                "");

            Assert.Equal(expectedResults, results);
        }
    }
}

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
        public void Should_save_changes_for_point_correctly()
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

        [Fact]
        public void Should_save_changes_for_lineSegment_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(new string[] { });

            var context = new GeometricEntitiesTxtDbContext(sourceIO.Object);
            
            var pointA = new Point(2, 2);
            var pointB = new Point(3, 3);
            var lineSegment = new LineSegment(pointA, pointB);
            context.Add(lineSegment);
            context.SaveChanges();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var results = new StreamReader(memoryStream).ReadToEnd();
            var expectedResults = string.Join(Environment.NewLine,
                " Id: 2",
                " X: 2",
                " Y: 2",
                "- Point",
                "",
                " Id: 3",
                " X: 3",
                " Y: 3",
                "- Point",
                "",
                " Id: 1",
                " A: 2",
                " B: 3",
                "- LineSegment",
                "",
                "");

            Assert.Equal(expectedResults, results);
        }

        [Fact]
        public void Should_save_changes_for_circle_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(new string[] { });

            var context = new GeometricEntitiesTxtDbContext(sourceIO.Object);

            var center = new Point(2, 2);
            var circle = new Circle(center, 5);
            context.Add(circle);
            context.SaveChanges();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var results = new StreamReader(memoryStream).ReadToEnd();
            var expectedResults = string.Join(Environment.NewLine,
                " Id: 2",
                " X: 2",
                " Y: 2",
                "- Point",
                "",
                " Id: 1",
                " Center: 2",
                " Radius: 5",
                "- Circle",
                "",
                "");

            Assert.Equal(expectedResults, results);
        }

        [Fact]
        public void Should_save_changes_for_rectangle_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(new string[] { });

            var context = new GeometricEntitiesTxtDbContext(sourceIO.Object);

            var pointA = new Point(1, 1);
            var pointB = new Point(1, 2);
            var pointC = new Point(5, 2);
            var pointD = new Point(5, 1);
            var rectangle = new Rectangle(pointA, pointB, pointC, pointD);
            context.Add(rectangle);
            context.SaveChanges();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var results = new StreamReader(memoryStream).ReadToEnd();
            var expectedResults = string.Join(Environment.NewLine,
                " Id: 2",
                " X: 1",
                " Y: 1",
                "- Point",
                "",
                " Id: 3",
                " X: 1",
                " Y: 2",
                "- Point",
                "",
                " Id: 4",
                " X: 5",
                " Y: 2",
                "- Point",
                "",
                " Id: 5",
                " X: 5",
                " Y: 1",
                "- Point",
                "",
                " Id: 1",
                " A: 2",
                " B: 3",
                " C: 4",
                " D: 5",
                "- Rectangle",
                "",
                "");

            Assert.Equal(expectedResults, results);
        }

        [Fact]
        public void Should_save_changes_for_triangle_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(new string[] { });

            var context = new GeometricEntitiesTxtDbContext(sourceIO.Object);

            var pointA = new Point(1, 1);
            var pointB = new Point(1, 2);
            var pointC = new Point(5, 2);
            var triangle = new Triangle(pointA, pointB, pointC);
            context.Add(triangle);
            context.SaveChanges();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var results = new StreamReader(memoryStream).ReadToEnd();
            var expectedResults = string.Join(Environment.NewLine,
                " Id: 2",
                " X: 1",
                " Y: 1",
                "- Point",
                "",
                " Id: 3",
                " X: 1",
                " Y: 2",
                "- Point",
                "",
                " Id: 4",
                " X: 5",
                " Y: 2",
                "- Point",
                "",
                " Id: 1",
                " A: 2",
                " B: 3",
                " C: 4",
                "- Triangle",
                "",
                "");

            Assert.Equal(expectedResults, results);
        }

        [Fact]
        public void Should_save_changes_for_ring_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(new string[] { });

            var context = new GeometricEntitiesTxtDbContext(sourceIO.Object);

            var center = new Point(1, 1);
            var ring = new Ring(center, 8, 5);
            context.Add(ring);
            context.SaveChanges();
            memoryStream.Seek(0, SeekOrigin.Begin);

            var results = new StreamReader(memoryStream).ReadToEnd();
            var expectedResults = string.Join(Environment.NewLine,
                " Id: 2",
                " X: 1",
                " Y: 1",
                "- Point",
                "",
                " Id: 1",
                " Center: 2",
                " Long radius: 8",
                " Short radius: 5",
                "- Ring",
                "",
                "");

            Assert.Equal(expectedResults, results);
        }
    }
}

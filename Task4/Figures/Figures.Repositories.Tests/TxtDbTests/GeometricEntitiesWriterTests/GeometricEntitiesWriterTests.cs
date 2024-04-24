using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
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
    public class GeometricEntitiesWriterTests
    {
        [Fact]
        public void Should_save_changes_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);
            var calledSave = false;

            var entityWriter = new Mock<IEntityWriter<Point>>();
            entityWriter
                .Setup(x => x.Save(It.IsAny<TestTextWriter>(), It.IsAny<Point>(), It.IsAny<IdGenerator>()))
                .Callback(() => calledSave = true);

            var writerMap = new Dictionary<string, IEntityWriter<GeometricEntity>>
            {
                {"Point", new EntityWriter<Point>(entityWriter.Object)}
            };

            var geometricEntitiesWriter = CreateEntitiesWriter(writer, writerMap);

            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                {1, new Point { X = 3, Y = 2 } }
            };

            var context = new GeometricEntitiesContext(entitiesMap);
            geometricEntitiesWriter.SaveChanges(context);
            Assert.True(calledSave);
        }

        [Fact]
        public void Should_throw_ArgumentException_correctly()
        {

            var sourceIO = new Mock<ISourceIO>();
            var writerMap = new Dictionary<string, IEntityWriter<GeometricEntity>>();
            var geometricEntitiesWriter = new GeometricEntitiesWriter(sourceIO.Object, writerMap);

            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                {1, new Point{ X = 1, Y = 2 } }
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            Action func = () => geometricEntitiesWriter.SaveChanges(context);
            Assert.Throws<ArgumentException>(() => func());
        }

        private GeometricEntitiesWriter CreateEntitiesWriter(TestTextWriter writer, Dictionary<string, IEntityWriter<GeometricEntity>> writersMap)
        {
            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            sourceIO
                .Setup(x => x.ReadAllLines())
                .Returns(Array.Empty<string>);

            return new GeometricEntitiesWriter(sourceIO.Object, writersMap);
        }
    }
}

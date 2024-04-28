using Figures.Model;
using Figures.Repositories.TxtDb.Writers;
using System;
using System.IO;
using Xunit;

namespace Figures.Repositories.Tests.TxtDbTests.GeometricEntitiesWriterTests
{
    public class PointWriterTests
    {
        [Fact]
        public void Should_save_changes_for_point_correctly()
        {
            using var memorySystem = new MemoryStream();
            using var txtWriter = new TestTextWriter(memorySystem);

            var writer = new PointWriter();
            var point = new Point { X = 1, Y = 1, Id = 1 };
            var idGenerator = new IdGenerator();
            idGenerator.Add(point.Id);

            writer.Save(txtWriter, point, idGenerator);

            memorySystem.Seek(0, SeekOrigin.Begin);

            var reader = new StreamReader(memorySystem);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
               " Id: 1",
               " X: 1",
               " Y: 1",
               "Point",
               "",
               "");

            Assert.Equal(expectedResults, results);
        }
    }
}

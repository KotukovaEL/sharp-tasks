using Figures.Model;
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
    public class PointWriterTests
    {
        [Fact]
        public void Should_save_changes_for_point_correctly()
        {
            using var memorySystem = new MemoryStream();
            using var txtWriter = new TestTextWriter(memorySystem);


            var point = new Point(1, 1);
            point.Id = 1;

            var writer = new PointWriter();
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

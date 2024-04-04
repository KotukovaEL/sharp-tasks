﻿using Figures.Model;
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
            var pointA = new Point(1, 1);
            var pointB = new Point(1, 3);
            var pointC = new Point(4, 3);
            var pointD = new Point(4, 1);
            var rectangle = new Rectangle(pointA, pointB, pointC, pointD) { Id = 1 };
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
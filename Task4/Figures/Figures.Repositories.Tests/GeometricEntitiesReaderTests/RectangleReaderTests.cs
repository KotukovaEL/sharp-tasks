﻿using Figures.Model;
using Figures.Repositories.Readers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.GeometricEntitiesReaderTests
{
    public class RectangleReaderTests
    {
        [Fact]
        public void Should_read_data_for_rectangle_correctly()
        {
            var entitiesMap = new Dictionary<int, GeometricEntity>
            {
                { 2, new Point(1, 1) {Id = 2 } },
                { 3, new Point(1, 3) {Id = 3 } },
                { 4, new Point(4, 3) {Id = 4 } },
                { 5, new Point(4, 1) {Id = 5 } },
            };

            var context = new GeometricEntitiesContext(entitiesMap);

            var fieldsMap = new Dictionary<string, string>
            {
                { "A", "2"},
                { "B", "3"},
                { "C", "4"},
                { "D", "5"},
                { "Id", "1"},
            };

            var rectangleReader = new RectangleReader();
            var results = rectangleReader.Read(fieldsMap, context);
            var expectedResults = new Rectangle(
                new Point(1, 1) { Id = 2 }, 
                new Point(1, 3) { Id = 3 }, 
                new Point(4, 3) { Id = 4 }, 
                new Point(4, 1) { Id = 5 }) 
            { Id = 1 };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}
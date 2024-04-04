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
    public class PointReaderTests
    {
        [Fact]
        public void Should_read_data_for_point_correctly()
        {
            var context = new GeometricEntitiesContext();

            var fieldsMap = new Dictionary<string, string>
            {
                { "X", "2"},
                { "Y", "3"},
                { "Id", "1"},
            };

            var pointReader = new PointReader();
            var results = pointReader.Read(fieldsMap, context);
            var expectedResults = new Point(2, 3) { Id = 1 };

            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}
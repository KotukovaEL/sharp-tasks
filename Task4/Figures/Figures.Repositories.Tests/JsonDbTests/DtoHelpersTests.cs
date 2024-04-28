using Figures.Model;
using Figures.Repositories.JsonDb;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.JsonDbTests
{
    public class DtoHelpersTests
    {
        [Fact]
        public void Should_add_entities_correctly()
        {
            var entityList = new List<GeometricEntity>
            {
                new Point { X = 1, Y = 2, Id = 1 },
                new Point { X = 1, Y = 3, Id = 2 },
            };

            var results = DtoHelpers.ConvertToDto(entityList);

            var pointList = new List<Point>
            {
                new Point { X = 1, Y = 2, Id = 1 },
                new Point { X = 1, Y = 3, Id = 2 },
            };

            var expectedResults = new GeometricEntitiesDto { Points = pointList };

            results.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_get_entities_correctly()
        {
            var geometricEntitiesDto = new GeometricEntitiesDto { Points = {
                new Point { X = 1, Y = 2, Id = 1 },
                new Point { X = 1, Y = 3, Id = 2 },}
            };

            var results = DtoHelpers.ConvertFromDto(geometricEntitiesDto);

            var pointList = new List<Point>
            {
                new Point { X = 1, Y = 2, Id = 1 },
                new Point { X = 1, Y = 3, Id = 2 },
            };

            var expectedResults = new Dictionary<int, GeometricEntity>
            {
                {1, new Point { X = 1, Y = 2, Id = 1 } },
                {2, new Point { X = 1, Y = 3, Id = 2 } },
            };

            Assert.Equal(expectedResults, results);
        }
    }
}

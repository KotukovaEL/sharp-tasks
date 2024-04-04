using Figures.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests
{
    public class IdGeneratorTests
    {
        [Fact]
        public void Should_reload_correctly()
        {
            var entity = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point(6, 8) { Id = 1 } },
                { 4, new Point(12, 12) { Id = 4 } },
            };

            var idGenerator = new IdGenerator();
            idGenerator.Reload(entity);
            //var expectedResults = new Point(6, 8) { Id = 1 };
            //entity.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_add_correctly()
        {
            var idGenerator = new IdGenerator();
            idGenerator.Add(1);
            //var expectedResults = new Point(6, 8) { Id = 1 };
            //entity.Should().BeEquivalentTo(expectedResults);
        }

        [Fact]
        public void Should_generator_correctly()
        {
            var idGenerator = new IdGenerator();
            var id = idGenerator.Generate();
            var expectedId = 1;
            Assert.Equal(expectedId, id);
        }
    }
}

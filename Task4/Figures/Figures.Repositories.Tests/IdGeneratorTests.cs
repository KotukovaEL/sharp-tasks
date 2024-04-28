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
        public void Should_generator_correctly()
        {
            var idGenerator = new IdGenerator();
            var id = idGenerator.Generate();
            var expectedId = 1;
            Assert.Equal(expectedId, id);
        }

        [Fact]
        public void Should_reload_and_generator_correctly()
        {
            var entity = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point { X = 6, Y = 8, Id = 1 } },
                { 4, new Point { X = 12, Y = 12, Id = 4 } },
            };

            var idGenerator = new IdGenerator();
            idGenerator.Reload(entity);
            var id = idGenerator.Generate();
            var expectedId = 5;
            Assert.Equal(expectedId, id);
        }

        [Fact]
        public void Should_add_and_generator_correctly()
        {
            var idGenerator = new IdGenerator();
            idGenerator.Add(1);
            var id = idGenerator.Generate();
            var expectedId = 2;
            Assert.Equal(expectedId, id);
        }

        [Fact]
        public void Should_add_reload_and_generator_correctly()
        {
            var entity = new Dictionary<int, GeometricEntity>
            {
                { 1, new Point { X = 6, Y = 8, Id = 1 } },
                { 4, new Point { X = 12, Y = 12, Id = 4 } },
            };

            var idGenerator = new IdGenerator();
            idGenerator.Reload(entity);
            idGenerator.Add(6);
            var id = idGenerator.Generate();
            var expectedId = 7;
            Assert.Equal(expectedId, id);
        }
    }
}

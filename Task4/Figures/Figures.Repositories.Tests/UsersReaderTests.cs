using Figures.Model;
using Figures.Repositories.Readers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests
{
    public class UsersReaderTests
    {
        public class GeometricEntitiesReaderTests
        {
            [Fact]
            public void Should_read_correctly()
            {
                var lines = new string[]
                {
                " Name: name",
                " EntityList: 1,2",
                "",
                };

                var sourceIO = new Mock<ISourceIO>();
                sourceIO
                    .Setup(x => x.ReadAllLines())
                    .Returns(lines);

                var userReader = new UsersReader(sourceIO.Object);
                var results = userReader.ReadFile();
                var user = new User("name");
                var entityList = new List<int> { 1, 2 };
                user.EntityIdList.AddRange(entityList);

                var usersMap = new Dictionary<string, User>()
            {
                { "name", user },
            };
                var expectedResults = usersMap;
                results.Should().BeEquivalentTo(expectedResults);
            }
        }
    }
}

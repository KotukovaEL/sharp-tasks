using Figures.Model;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
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
                var user = new User { Name = "name" };
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

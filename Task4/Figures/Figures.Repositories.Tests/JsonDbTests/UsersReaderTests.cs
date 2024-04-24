using Figures.Model;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.JsonDbTests
{
    public class UsersReaderTests
    {
        [Fact]
        public void Should_read_correctly()
        {
            var jsonStr = "{\r\n  \"name\": {\r\n    \"Name\": \"name\",\r\n    \"EntityIdList\": [\r\n      1\r\n    ]\r\n  }\r\n}";

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.ReadAllText())
                .Returns(jsonStr);

            var userReader = new JsonDb.UsersReader(sourceIO.Object);
            var results = userReader.ReadFile();

            var user = new User { Name = "name" };
            user.EntityIdList = new List<int> { 1 };

            var usersMap = new Dictionary<string, User>()
            {
                { "name", user },
            };
            var expectedResults = usersMap;
            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}

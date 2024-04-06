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

namespace Figures.Repositories.Tests
{
    public class UsersWriterTests
    {
        [Fact]
        public void Should_save_changes_correctly()
        {
            using var memoryStream = new MemoryStream();
            using var writer = new TestTextWriter(memoryStream);

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.CreateWriter())
                .Returns(writer);

            var usersWriter = new UsersWriter(sourceIO.Object);
            var user = new User("name");
            var entityList = new List<int> { 1, 2 };
            user.EntityIdList.AddRange(entityList);

            var userMap = new Dictionary<string, User>
            {
                {"name", user}
            };

            usersWriter.SaveChanges(userMap);
            memoryStream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(memoryStream);
            var results = reader.ReadToEnd();

            var expectedResults = string.Join(Environment.NewLine,
               " Name: name",
               " EntityList: 1,2",
               "",
               "");

            Assert.Equal(expectedResults, results);
        }
    }
}

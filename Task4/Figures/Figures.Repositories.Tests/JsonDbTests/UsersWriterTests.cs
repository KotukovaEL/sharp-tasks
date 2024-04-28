using Figures.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Repositories.Tests.JsonDbTests
{
    public class UsersWriterTests
    {
        [Fact]
        public void Should_save_changes_correctly()
        {
            var calledWriteAllText = false;
            var jsonStr = @"{
  ""name"": {
    ""Name"": ""name"",
    ""EntityIdList"": [
      1
    ]
  }
}";

            var sourceIO = new Mock<ISourceIO>();
            sourceIO
                .Setup(x => x.WriteAllText(jsonStr))
                .Callback(() => calledWriteAllText = true);

            var user = new User { Name = "name" };
            user.EntityIdList = new List<int> { 1 };

            var usersMap = new Dictionary<string, User>()
            {
                { "name", user },
            };

            var usersWriter = new JsonDb.UsersWriter(sourceIO.Object);
            usersWriter.SaveChanges(usersMap);
            Assert.True(calledWriteAllText);
        }
    }
}

using Figures.Common.Interfaces;
using Figures.Model;
using Figures.Repositories.Interface;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Xunit;

namespace Figures.Repositories.Tests
{
    public class UsersRepositoryTests
    {
        [Fact]
        public void Should_try_add_user_correctly()
        {
            var calledSaveChanges = false;
            var usersWriter = new Mock<IUsersWriter>();
            usersWriter
                .Setup(x => x.SaveChanges(It.IsAny<Dictionary<string, User>>()))
                .Callback(() => calledSaveChanges = true);

            var usersMap = new Dictionary<string, User>
            {
                { "name", new User("name")},
            };

            var usersReader = new Mock<IUsersReader>();
            usersReader
                .Setup(x => x.ReadFile())
                .Returns(usersMap);

            var repo = new UsersRepository(usersWriter.Object, usersReader.Object);
            var expectedUser = new User("Name");
            repo.TryAdd(expectedUser.Name);
            Assert.True(calledSaveChanges);
        }

        [Fact]
        public void Should_get_user_correctly()
        {
            var usersWriter = new Mock<IUsersWriter>();
            var usersMap = new Dictionary<string, User>
            {
                { "name", new User("name")},
            };

            var usersReader = new Mock<IUsersReader>();
            usersReader
                .Setup(x => x.ReadFile())
                .Returns(usersMap);

            var repo = new UsersRepository(usersWriter.Object, usersReader.Object);
            var results = repo.GetUser("name");
            var expectedUser = new User("name");
            results.Should().BeEquivalentTo(expectedUser);
        }

        [Fact]
        public void Should_add_figure_correctly()
        {
            var calledSaveChanges = false;
            var usersMap = new Dictionary<string, User>
            {
                { "name", new User("name")},
            };

            var usersWriter = new Mock<IUsersWriter>();
            usersWriter
                .Setup(x => x.SaveChanges(It.IsAny<Dictionary<string, User>>())) //можно ли так сделать?
                .Callback(() => calledSaveChanges = true);

            var usersReader = new Mock<IUsersReader>();
            usersReader
                .Setup(x => x.ReadFile())
                .Returns(usersMap);

            var repo = new UsersRepository(usersWriter.Object, usersReader.Object);
            repo.AddFigure("name", 1);
            Assert.True(calledSaveChanges);
        }

        [Fact]
        public void Should_get_by_key_correctly()
        {
            var usersWriter = new Mock<IUsersWriter>();
            var usersMap = new Dictionary<string, User>
            {
                { "name", new User("name")},
            };

            var usersReader = new Mock<IUsersReader>();
            usersReader
                .Setup(x => x.ReadFile())
                .Returns(usersMap);

            var repo = new UsersRepository(usersWriter.Object, usersReader.Object);
            var results = repo.GetByKey("name");
            var expectedUser = new User("name");
            results.Should().BeEquivalentTo(expectedUser);
        }
    }
}

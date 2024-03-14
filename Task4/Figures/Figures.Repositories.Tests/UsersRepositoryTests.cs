using Figures.Common.Interfaces;
using Figures.Model;
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
            User? userFromRepo = null;
            var context = new Mock<ITxtDbContext<string, User>>();
            context
                .Setup(x => x.Add(It.IsAny<User>()))
                .Callback((User user) => userFromRepo = user);

            context
                .Setup(x => x.SaveChanges())
                .Callback(() => calledSaveChanges = true);

            var repo = new UsersRepository(context.Object);
            var expectedUser = new User("Name");
            repo.TryAdd(expectedUser.Name);
            userFromRepo.Should().BeEquivalentTo(expectedUser);
            Assert.True(calledSaveChanges);
        }

        [Fact]
        public void Should_get_user_correctly()
        {
            var userFromRepo = new User("Name");
            var context = new Mock<ITxtDbContext<string, User>>();
            context
                .Setup(x => x.GetByKey(It.IsAny<string>()))
                .Returns(userFromRepo);

            var repo = new UsersRepository(context.Object);
            var expectedUser = repo.GetUser(userFromRepo.Name);
            userFromRepo.Should().BeEquivalentTo(expectedUser);
        }
    }
}

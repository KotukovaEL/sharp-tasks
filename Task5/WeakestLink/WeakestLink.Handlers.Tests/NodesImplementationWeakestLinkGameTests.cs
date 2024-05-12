using Moq;
using System.Text;
using WeakestLink.Handlers.NodesImplementation;
using Xunit;

namespace WeakestLink.Handlers.Tests
{
    public class NodesImplementationWeakestLinkGameTests
    {
        [Fact]
        public void Should_run_WeakestLinkGame_NodesImplementation_correctly()
        {
            var sb = new StringBuilder();

            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() =>
                {
                    return sb.ToString();
                });

            var weakestLinkGame = new WeakestLinkGame(userInteractor.Object);
            weakestLinkGame.Run(5, 2);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 2",
                "Раунд 1. Вычеркнут 2 человек. Людей осталось: 4",
                "Раунд 2. Вычеркнут 4 человек. Людей осталось: 3",
                "Раунд 3. Вычеркнут 1 человек. Людей осталось: 2",
                "Раунд 4. Вычеркнут 5 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 3");

            Assert.Equal(expectedOutput, sb.ToString());
        }
    }
}

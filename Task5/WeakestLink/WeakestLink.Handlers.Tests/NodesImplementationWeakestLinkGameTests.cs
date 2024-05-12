using Moq;
using System.Text;
using WeakestLink.Handlers.NodesImplementation;
using Xunit;

namespace WeakestLink.Handlers.Tests
{
    public class NodesImplementationWeakestLinkGameTests
    {
        [Fact]
        public void Should_run_WeakestLinkGame_NodesImplementation_when_number_of_players_is_odd_and_every_2_are_strikeout_correctly()
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

        [Fact]
        public void Should_run_WeakestLinkGame_NodesImplementation_when_number_of_players_is_even_and_every_2_are_strikeout_correctly()
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
            weakestLinkGame.Run(4, 2);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 2",
                "Раунд 1. Вычеркнут 2 человек. Людей осталось: 3",
                "Раунд 2. Вычеркнут 4 человек. Людей осталось: 2",
                "Раунд 3. Вычеркнут 3 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 1");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Fact]
        public void Should_run_WeakestLinkGame_NodesImplementation_when_number_of_players_is_even_and_every_3_are_strikeout_correctly()
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
            weakestLinkGame.Run(4, 3);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 3",
                "Раунд 1. Вычеркнут 3 человек. Людей осталось: 3",
                "Раунд 2. Вычеркнут 2 человек. Людей осталось: 2",
                "Раунд 3. Вычеркнут 4 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 1");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Fact]
        public void Should_run_WeakestLinkGame_NodesImplementation_when_number_of_players_is_odd_and_every_3_are_strikeout_correctly()
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
            weakestLinkGame.Run(5, 3);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 3",
                "Раунд 1. Вычеркнут 3 человек. Людей осталось: 4",
                "Раунд 2. Вычеркнут 1 человек. Людей осталось: 3",
                "Раунд 3. Вычеркнут 5 человек. Людей осталось: 2",
                "Раунд 4. Вычеркнут 2 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 4");

            Assert.Equal(expectedOutput, sb.ToString());
        }
    }
}

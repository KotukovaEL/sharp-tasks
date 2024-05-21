using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using System;
using System.Text;
using System.Xml.Linq;
using Xunit;

namespace WeakestLink.Handlers.Tests
{
    public class WeakestLinkGameTests
    {
        [Theory]
        [InlineData(GameImplementation.List)]
        [InlineData(GameImplementation.Nodes)]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_odd_and_every_2_are_strikeout_correctly(GameImplementation gameImplementation)
        {
            var sb = new StringBuilder();
            var weakestLinkGame = CreateWeakestLinkGame(gameImplementation, sb);
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

        [Theory]
        [InlineData(GameImplementation.List)]
        [InlineData(GameImplementation.Nodes)]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_even_and_every_2_are_strikeout_correctly(GameImplementation gameImplementation)
        {
            var sb = new StringBuilder();
            var weakestLinkGame = CreateWeakestLinkGame(gameImplementation, sb);
            weakestLinkGame.Run(10, 2);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 2",
                "Раунд 1. Вычеркнут 2 человек. Людей осталось: 9",
                "Раунд 2. Вычеркнут 4 человек. Людей осталось: 8",
                "Раунд 3. Вычеркнут 6 человек. Людей осталось: 7",
                "Раунд 4. Вычеркнут 8 человек. Людей осталось: 6",
                "Раунд 5. Вычеркнут 10 человек. Людей осталось: 5",
                "Раунд 6. Вычеркнут 3 человек. Людей осталось: 4",
                "Раунд 7. Вычеркнут 7 человек. Людей осталось: 3",
                "Раунд 8. Вычеркнут 1 человек. Людей осталось: 2",
                "Раунд 9. Вычеркнут 9 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 5");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Theory]
        [InlineData(GameImplementation.List)]
        [InlineData(GameImplementation.Nodes)]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_even_and_every_3_are_strikeout_correctly(GameImplementation gameImplementation)
        {
            var sb = new StringBuilder();
            var weakestLinkGame = CreateWeakestLinkGame(gameImplementation, sb);
            weakestLinkGame.Run(10, 5);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 5",
                "Раунд 1. Вычеркнут 5 человек. Людей осталось: 9",
                "Раунд 2. Вычеркнут 10 человек. Людей осталось: 8",
                "Раунд 3. Вычеркнут 6 человек. Людей осталось: 7",
                "Раунд 4. Вычеркнут 2 человек. Людей осталось: 6",
                "Раунд 5. Вычеркнут 9 человек. Людей осталось: 5",
                "Раунд 6. Вычеркнут 8 человек. Людей осталось: 4",
                "Раунд 7. Вычеркнут 1 человек. Людей осталось: 3",
                "Раунд 8. Вычеркнут 4 человек. Людей осталось: 2",
                "Раунд 9. Вычеркнут 7 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 3");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        [Theory]
        [InlineData(GameImplementation.List)]
        [InlineData(GameImplementation.Nodes)]
        public void Should_run_WeakestLinkGame_ListImplementation_when_number_of_players_is_odd_and_every_5_are_strikeout_correctly(GameImplementation gameImplementation)
        {
            var sb = new StringBuilder();
            var weakestLinkGame = CreateWeakestLinkGame(gameImplementation, sb);
            weakestLinkGame.Run(5, 5);
            string expectedOutput = string.Join(null,
                "Сгенерирован круг людей. Начинаем вычеркивать каждого 5",
                "Раунд 1. Вычеркнут 5 человек. Людей осталось: 4",
                "Раунд 2. Вычеркнут 1 человек. Людей осталось: 3",
                "Раунд 3. Вычеркнут 3 человек. Людей осталось: 2",
                "Раунд 4. Вычеркнут 4 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 2");

            Assert.Equal(expectedOutput, sb.ToString());
        }

        private static IWeakestLinkGame CreateWeakestLinkGame(GameImplementation gameImplementation, StringBuilder sb)
        {
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

            switch (gameImplementation)
            {
                case GameImplementation.Nodes:
                    return new NodesImplementation.WeakestLinkGame(userInteractor.Object);
                case GameImplementation.List:
                    return new ListImplementation.WeakestLinkGame(userInteractor.Object);
                default: 
                    throw new ArgumentException("Таких вариантов нет");
            }
        }
    }
}

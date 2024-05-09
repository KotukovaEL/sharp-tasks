using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WeakestLink.Handlers.Tests
{
    public class WeakestLinkAppHandlerTests
    {
        [Fact]
        public void Should_run_WeakestLinkAppHandler_correctly()
        {
            var sb = new StringBuilder();
            var inputIndex = 0;
            var inputs = new[] { "5", "2"};
            var calledRun = false;
            var userInteractor = new Mock<IUserInteractor>();
            userInteractor
                .Setup(x => x.PrintMessage(It.IsAny<string>()))
                .Callback((string message) => sb.Append(message));

            userInteractor
                .Setup(x => x.ReadStr())
                .Returns(() =>
                {
                    var input = inputs[inputIndex];
                    inputIndex++;
                    return input;
                });

            var weakestLinkGame = new Mock<IWeakestLinkGame>();
            weakestLinkGame
                .Setup(x => x.Run(It.IsAny<int>(), It.IsAny<int>()))
                .Callback((int playersCount, int strikeoutNumber) => calledRun = true);

            var weakestLinkAppHandler = new WeakestLinkAppHandler(userInteractor.Object, weakestLinkGame.Object);
            weakestLinkAppHandler.Run();
            string expectedOutput = string.Join(null,
                "Введите N: ",
                "5",
                "Введите, какой по счету человек будет вычеркнут каждый раунд: ",
                "2",
                 "Сгенерирован круг людей. Начинаем вычеркивать каждого 2",
                "Раунд 1. Вычеркнут 2 человек. Людей осталось: 4",
                "Раунд 2. Вычеркнут 4 человек. Людей осталось: 3",
                "Раунд 3. Вычеркнут 1 человек. Людей осталось: 2",
                "Раунд 4. Вычеркнут 5 человек. Людей осталось: 1",
                "Игра окончена. Невозможно вычеркнуть больше людей. Победитель 3"
                );

            Assert.Equal(expectedOutput, sb.ToString());
            Assert.True(calledRun);
        }
    }
}
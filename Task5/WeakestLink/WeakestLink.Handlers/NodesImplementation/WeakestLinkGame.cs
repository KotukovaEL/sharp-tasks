using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers.NodesImplementation
{
    public class WeakestLinkGame : IWeakestLinkGame
    {
        private readonly IUserInteractor _userInteractor;

        public WeakestLinkGame(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Run(int playersCount, int strikeoutNumber)
        {            
            var currentPlayer = GenerateNodes(playersCount);
            _userInteractor.PrintMessage($"Сгенерирован круг людей. Начинаем вычеркивать каждого {strikeoutNumber}");
            var strikeoutCount = 0;
            var round = 0;
     
            while (currentPlayer?.Next is not null)
            {
                strikeoutCount++;

                if (strikeoutCount == strikeoutNumber)
                {
                    round++;
                    playersCount--;
                    _userInteractor.PrintMessage($"Раунд {round}. Вычеркнут {currentPlayer.Previous.Number} человек. Людей осталось: {playersCount}");
                    currentPlayer.Previous.Next = currentPlayer.Next;
                    currentPlayer.Next.Previous = currentPlayer.Previous;
                    currentPlayer = currentPlayer.Next;
                    strikeoutCount = 0;
                    continue;
                }

                if (currentPlayer.Next == currentPlayer)
                {
                    currentPlayer.Next = null;
                    currentPlayer.Previous = null;
                    continue;
                }

                currentPlayer = currentPlayer.Next;
            }

            _userInteractor.PrintMessage($"Игра окончена. Невозможно вычеркнуть больше людей. Победитель {currentPlayer.Number}");
        }

        private Player GenerateNodes(int playersCount)
        {
            var firstPlayer = new Player
            {
                Number = 1,
                Next = null,
                Previous = null
            };

            var currentPlayer = firstPlayer;

            for (int i = 2; i <= playersCount; i++)
            {
                var nextPlayer = new Player
                {
                    Number = i,
                    Next = null,
                    Previous = currentPlayer
                };

                currentPlayer.Next = nextPlayer;
                currentPlayer = nextPlayer;

                if (i == playersCount)
                {
                    currentPlayer.Next = firstPlayer;
                    firstPlayer.Previous = currentPlayer;
                }
            }

            return firstPlayer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakestLink.Handlers
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
            var round = 0;
            var strikeoutIndex = 0;
            var players = Enumerable.Range(1, playersCount).ToList();
            _userInteractor.PrintMessage($"Сгенерирован круг людей. Начинаем вычеркивать каждого {strikeoutNumber}");

            while (players.Count > 1)
            {
                strikeoutIndex += strikeoutNumber - 1;
                strikeoutIndex %= players.Count;
                var removedPlayer = players[strikeoutIndex];
                players.RemoveAt(strikeoutIndex);
                round++;

                _userInteractor.PrintMessage($"Раунд {round}. Вычеркнут {removedPlayer} человек. Людей осталось: {players.Count}");
            }

            _userInteractor.PrintMessage($"Игра окончена. Невозможно вычеркнуть больше людей. Победитель {players[0]}");
        }
    }
}

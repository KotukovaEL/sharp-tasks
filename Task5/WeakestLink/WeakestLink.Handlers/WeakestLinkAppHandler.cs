using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public class WeakestLinkAppHandler
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IWeakestLinkGame _weakestLinkGame;

        public WeakestLinkAppHandler(IUserInteractor userInteractor, IWeakestLinkGame weakestLinkGame)
        {
            _userInteractor = userInteractor;
            _weakestLinkGame = weakestLinkGame;
        }

        public void Run()
        {
            _userInteractor.PrintMessage("Введите N: ");
            var playersCount = int.Parse(_userInteractor.ReadStr());
            
            _userInteractor.PrintMessage("Введите, какой по счету человек будет вычеркнут каждый раунд: ");
            var strikeoutNumber = int.Parse(_userInteractor.ReadStr());

            if (strikeoutNumber < 2)
            {
                throw new ArgumentException($"Игра окончена. Невозможно вычеркнуть людей, так как вычеркивается каждый {strikeoutNumber}");
            }
            _weakestLinkGame.Run(playersCount, strikeoutNumber);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public static class DeletionPeople
    {
        public static void DeletePeople(List<int> peopleList, int numberPersonDelete, IUserInteractor userInteractor)
        {
            var round = 0;
            var numberDelete = 0;

            while(peopleList.Count > 1)
            {
                numberDelete = numberDelete + numberPersonDelete - 1;
                numberDelete = numberDelete % peopleList.Count;
                var peopleDelete = peopleList[numberDelete];
                peopleList.RemoveAt(numberDelete);
                round++;

                userInteractor.PrintMessage($"Раунд {round}. Вычеркнут {peopleDelete} человек. Людей осталось: {peopleList.Count}");
              }

            userInteractor.PrintMessage("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
    }
}

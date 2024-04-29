using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public static class DeletionPeople
    {
        public static void DeletePeople(List<int> peopleList, int numberPersonDelete, IUserInteractor userInteractor)
        {
            var j = 0;
            var i = 0;

            while(peopleList.Count > 1)
            {
                i = i + numberPersonDelete - 1;
                i = i % peopleList.Count;
                var peopleDelete = peopleList[i];
                peopleList.RemoveAt(i);
                j++;

                userInteractor.PrintMessage($"Раунд {j}. Вычеркнут {peopleDelete} человек. Людей осталось: {peopleList.Count}");
              }

            userInteractor.PrintMessage("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
    }
}

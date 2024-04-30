using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public static class DeletionPeople
    {
        public static void DeletePeople(List<int> peopleList, int numberPersonDelete, IUserInteractor userInteractor)
        {
            var round = 0;
            var deletingNumber = 0;

            while(peopleList.Count > 1)
            {
                deletingNumber = deletingNumber + numberPersonDelete - 1;
                deletingNumber = deletingNumber % peopleList.Count;
                var peopleDelete = peopleList[deletingNumber];
                peopleList.RemoveAt(deletingNumber);
                round++;

                userInteractor.PrintMessage($"Раунд {round}. Вычеркнут {peopleDelete} человек. Людей осталось: {peopleList.Count}");
              }

            userInteractor.PrintMessage("Игра окончена. Невозможно вычеркнуть больше людей.");
        }
    }
}

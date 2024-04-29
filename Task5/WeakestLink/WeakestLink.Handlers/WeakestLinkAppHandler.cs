using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public class WeakestLinkAppHandler
    {
        private readonly IUserInteractor _userInteractor;

        public WeakestLinkAppHandler(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Run()
        {
            _userInteractor.PrintMessage("Введите N: ");
            var numberPeople = Validations.IntValid(_userInteractor, _userInteractor.ReadStr());
            
            _userInteractor.PrintMessage("Введите, какой по счету человек будет вычеркнут каждый раунд: ");
            var numberPersonDelete = Validations.IntValid(_userInteractor, _userInteractor.ReadStr()); 
            
            _userInteractor.PrintMessage($"Сгенерирован круг людей. Начинаем вычеркивать каждого {numberPersonDelete}");
            
            var peopleList = CompletionList.CompleteList(numberPeople);
            DeletionPeople.DeletePeople(peopleList, numberPersonDelete, _userInteractor);
        }
    }
}

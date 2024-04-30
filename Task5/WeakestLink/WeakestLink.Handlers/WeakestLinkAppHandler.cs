using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public class WeakestLinkAppHandler
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IFillingList _fillingList;

        public WeakestLinkAppHandler(IUserInteractor userInteractor, IFillingList fillingList)
        {
            _userInteractor = userInteractor;
            _fillingList = fillingList;
        }

        public void Run()
        {
            _userInteractor.PrintMessage("Введите N: ");
            var numberPeople = Parsing.IntParse(_userInteractor, _userInteractor.ReadStr());
            
            _userInteractor.PrintMessage("Введите, какой по счету человек будет вычеркнут каждый раунд: ");
            var numberPersonDelete = Parsing.IntParse(_userInteractor, _userInteractor.ReadStr()); 
            
            _userInteractor.PrintMessage($"Сгенерирован круг людей. Начинаем вычеркивать каждого {numberPersonDelete}");
            
            var peopleList = _fillingList.FillList(numberPeople);
            DeletionPeople.DeletePeople(peopleList, numberPersonDelete, _userInteractor);
        }
    }
}

using System;

namespace Figures.Services
{
    public class FiguresAppLogic 
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IEntitiesCreator _entitiesCreator;
        private readonly IGeometricEntitiesRepository _geometricEntitiesRepository;

        public FiguresAppLogic(IUserInteractor userInteractor, IEntitiesCreator entitiesCreator, IGeometricEntitiesRepository geometricEntitiesRepository)
        {
            _userInteractor = userInteractor;
            _entitiesCreator = entitiesCreator;
            _geometricEntitiesRepository = geometricEntitiesRepository;
        }
        public void Run()
        {
            _geometricEntitiesRepository.ReadFile();

            while (true)
            {
                var action = EnterAction();

                switch (action)
                {
                    case Actions.Exit:
                        return;

                    case Actions.Add:
                        AddEntity();
                        break;

                    case Actions.Output:
                        PrintEntities();
                        break;

                    //case Actions.ChangeUser:
                    //    user = Authorize();
                    //    break;

                    case Actions.Clear:
                        _geometricEntitiesRepository.DeleteAll();
                        break;

                }
            }
        }

        private Actions EnterAction()
        {
            _userInteractor.PrintMessage($"Выберите действие: ");
            MenuHelpers.PrintActions(_userInteractor);

            if (!EnumHelpers.TryReadEnum(_userInteractor.ReadStr(), out Actions action))
            {
                _userInteractor.PrintMessage($"Попытайся заново");
                return Actions.None;
            }
            return action;
        }

        private void AddEntity()
        {
            _userInteractor.PrintMessage($"Выберите тип фигуры: ");
            try
            {
                var figure = _entitiesCreator.CreateEntity();
                _geometricEntitiesRepository.Add(figure);
                _userInteractor.PrintMessage($"Фигура {figure.GetType().Name} создана!");
            }
            catch (Exception ex)
            {
                _userInteractor.PrintMessage($"Произошла ошибка {ex.Message}.");
            }
        }

        private void PrintEntities()
        {
            foreach (var entity in _geometricEntitiesRepository.List())
            {
                _userInteractor.PrintMessage(entity.ToString());
            }
        }

        //private string Authorize()
        //{
        //    var name = ReadUserName();
        //    _usersService.Authorize(name);
        //    return name;
        //}

        //private string ReadUserName()
        //{
        //    do
        //    {
        //        _userInteractor.PrintMessage("Введите имя пользователя: ");
        //        var nameUser = _userInteractor.ReadStr();

        //        if (!string.IsNullOrWhiteSpace(nameUser))
        //        {
        //            return nameUser;
        //        }

        //        _userInteractor.PrintMessage("Попытайтесь заново");
        //    }
        //    while (true);
        //}
    }
}

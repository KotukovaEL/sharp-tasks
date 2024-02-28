using System;

namespace Figures.Services
{
    public class FiguresAppLogic 
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IEntitiesCreator _entitiesCreator;
        private readonly UsersService _usersService;

        public FiguresAppLogic(IUserInteractor userInteractor, IEntitiesCreator entitiesCreator, UsersService usersService)
        {
            _userInteractor = userInteractor;
            _entitiesCreator = entitiesCreator;
            _usersService = usersService;
        }
        public void Run()
        {
            var user = Authorize();

            while (true)
            {                
                var action = EnterAction(user);

                switch (action)
                {
                    case Actions.Exit:
                        return;

                    case Actions.Add:
                        AddEntity(user);
                        break;

                    case Actions.Output:
                        PrintEntities(user);
                        break;

                    case Actions.ChangeUser:
                        user = Authorize();
                        break;

                    case Actions.Clear:
                        _usersService.DeleteFigures(user);
                        break;

                }
            }
        }

        private Actions EnterAction(string name)
        {
            _userInteractor.PrintMessage($"{name}, выберите действие: ");
            MenuHelpers.PrintActions(_userInteractor);

            if (!EnumHelpers.TryReadEnum(_userInteractor.ReadStr(), out Actions action))
            {
                _userInteractor.PrintMessage($"Попытайся заново");
                return Actions.None;
            }
            return action;
        }

        private void AddEntity(string name)
        {
            _userInteractor.PrintMessage($"{name}, выберите тип фигуры: ");

            try
            {
                var figure = _entitiesCreator.CreateEntity();
                _usersService.AddFigure(name, figure);
                _userInteractor.PrintMessage($"Фигура {figure.GetType().Name} создана!");
            }
            catch (Exception ex)
            {
                _userInteractor.PrintMessage($"Произошла ошибка {ex.Message}.");
            }
        }

        private void PrintEntities(string name)
        {
            _userInteractor.PrintMessage($"Список фигур пользователя {name}");

            foreach (var entity in _usersService.ListFigures(name))
            {
                _userInteractor.PrintMessage(entity.ToString());
            }

            if (_usersService.ListFigures(name).Count == 0)
            {
                _userInteractor.PrintMessage("Список Пуст");
            }
        }

        private string Authorize()
        {
            var name = ReadUserName();
            _usersService.Authorize(name);
            return name;
        }

        private string ReadUserName()
        {
            do
            {
                _userInteractor.PrintMessage("Введите имя пользователя: ");
                var nameUser = _userInteractor.ReadStr();

                if (!string.IsNullOrWhiteSpace(nameUser))
                {
                    return nameUser;
                }

                _userInteractor.PrintMessage("Попытайтесь заново");
            }
            while (true);
        }
    }
}

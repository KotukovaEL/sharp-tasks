using Figures.ConsoleApp;
using Figures.Model;
using InterfaceFigure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Services
{
    public class FiguresAppLogic 
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IGeometricEntitiesRepository _geometricEntitiesRepository;
        private readonly IEntitiesCreator _entitiesCreator;

        public FiguresAppLogic(IUserInteractor userInteractor, IGeometricEntitiesRepository geometricEntitiesRepository, IEntitiesCreator entitiesCreator)
        {
            _userInteractor = userInteractor;
            _geometricEntitiesRepository = geometricEntitiesRepository;
            _entitiesCreator = entitiesCreator;
        }
        public void Run()
        {
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

                    case Actions.Clear:
                        _geometricEntitiesRepository.DeleteAll();
                        break;
                }
            }
        }

        private Actions EnterAction()
        {
            MenuHelpers.PrintActions(_userInteractor);

            if (!EnumHelpers.TryReadEnum(_userInteractor.ReadStr(), out Actions action))
            {
                _userInteractor.PrintMessage("Попытайся заново");
                return Actions.None;
            }
            return action;
        }

        private void AddEntity()
        {
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
    }
}

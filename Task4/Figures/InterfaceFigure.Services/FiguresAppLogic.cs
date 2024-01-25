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
        private readonly EntitiesCreator _entitiesCreator;

        public FiguresAppLogic(EntitiesCreator entitiesCreator, IGeometricEntitiesRepository geometricEntitiesRepository, IUserInteractor userInteractor)
        {
            _entitiesCreator = entitiesCreator;
            _geometricEntitiesRepository = geometricEntitiesRepository;
            _userInteractor = userInteractor;
        }

        public void Run()
        {
            while (true)
            {
                MenuHelpers.PrintActions(_userInteractor);

                if (!TryReadEnum(Console.ReadLine(), out Actions result))
                {
                    _userInteractor.PrintMessage("Попытайся заново");
                    continue;
                }

                switch (result)
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

        private void AddEntity()
        {
            var type = EnterEntityType();
            GeometricEntity figure;

            try
            {
                figure = CreateEntityByType(type);
            }
            catch (Exception ex)
            {
                _userInteractor.PrintMessage("Произошла ошибка");
                _userInteractor.PrintMessage(ex.Message);
                return;
            }

            _geometricEntitiesRepository.Add(figure);
            _userInteractor.PrintMessage($"Фигура {type} создана!");
        }

        private GeometricEntityTypes EnterEntityType()
        {
            MenuHelpers.PrintGeometricEntityTypes(_userInteractor);

            if (!TryReadEnum(_userInteractor.ReadValue(), out GeometricEntityTypes result))
            {
                return GeometricEntityTypes.None;
            }

            return result;
        }

        private bool TryReadEnum<T>(string str, out T type) where T : struct, Enum
        {
            if (!Enum.TryParse(str, out type))
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(T), str))
            {
                return false;
            }

            return true;
        }
        private GeometricEntity CreateEntityByType(GeometricEntityTypes geometricFigure) => geometricFigure switch
        {
            GeometricEntityTypes.Circle =>  _entitiesCreator.CreateCircle(),
            GeometricEntityTypes.LineSegment => _entitiesCreator.CreateLineSegment(),
            GeometricEntityTypes.Rectangle => _entitiesCreator.CreateRectangle(),
            GeometricEntityTypes.Ring => _entitiesCreator.CreateRing(),
            GeometricEntityTypes.Triangle => _entitiesCreator.CreateTriangle(),
            GeometricEntityTypes.Point => _entitiesCreator.CreatePoint(),
            _ => throw new ArgumentException("There is no such figure."),
        };

        private void PrintEntities()
        {
            foreach (var entity in _geometricEntitiesRepository.List())
            {
                Console.WriteLine(entity.ToString());
            }
        }
    }
}

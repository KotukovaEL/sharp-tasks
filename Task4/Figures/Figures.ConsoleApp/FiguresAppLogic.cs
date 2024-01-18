using Figures.Model;
using Figures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class FiguresAppLogic
    {
        private readonly GeometricEntitiesRepository geometricEntitiesRepository;
        public FiguresAppLogic()
        {
            geometricEntitiesRepository = new GeometricEntitiesRepository();
        }
        public void Run()
        {
            while (true)
            {
                MenuHelpers.PrintActions();

                if (!TryReadEnum(Console.ReadLine(), out Actions result))
                {
                    Console.WriteLine("Попытайся заново");
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
                        geometricEntitiesRepository.DeleteAll();
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
                Console.WriteLine("Произошла ошибка");
                Console.WriteLine(ex.Message);
                return;
            }

            geometricEntitiesRepository.Add(figure);
            Console.WriteLine($"Фигура {type} создана!");
        }

        private GeometricEntityTypes EnterEntityType()
        {
            MenuHelpers.PrintGeometricEntityTypes();

            if (!TryReadEnum(Console.ReadLine(), out GeometricEntityTypes result))
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

            if (!Enum.IsDefined(type))
            {
                return false;
            }

            return true;
        }
        private GeometricEntity CreateEntityByType(GeometricEntityTypes geometricFigure) => geometricFigure switch
        {
            GeometricEntityTypes.Circle => EntitiesCreator.CreateCircle(),
            GeometricEntityTypes.LineSegment => EntitiesCreator.CreateLineSegment(),
            GeometricEntityTypes.Rectangle => EntitiesCreator.CreateRectangle(),
            GeometricEntityTypes.Ring => EntitiesCreator.CreateRing(),
            GeometricEntityTypes.Triangle => EntitiesCreator.CreateTriangle(),
            GeometricEntityTypes.Point => EntitiesCreator.CreatePoint(),
            _ => throw new ArgumentException("There is no such figure."),
        };

        private void PrintEntities()
        {
            foreach (var entity in geometricEntitiesRepository.List())
            {
                Console.WriteLine(entity.ToString());
            }
        }
    }
}

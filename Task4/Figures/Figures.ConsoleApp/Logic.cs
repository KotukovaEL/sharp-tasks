using Figures.Model;
using Figures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class Logic
    {
        private readonly GeometricEntitiesRepository geometricEntitiesRepository;
        public Logic()
        {
            geometricEntitiesRepository = new GeometricEntitiesRepository();
        }
        public void SelectAnAction()
        {

            while (true)
            {
                PrintOnConsole.PrintActions();

                if (!TryReadTypeForActions(Console.ReadLine(), out Actions result))
                {
                    Console.WriteLine("Попытайся заново");
                    continue;
                }

                if (result == Actions.Exit)
                {
                    return;
                }

                if (result == Actions.Add)
                {
                    ValidateNumberForGeometricEntityTypes();
                }

                if (result == Actions.Output)
                {
                    foreach (var entity in geometricEntitiesRepository.List())
                    {
                        Console.WriteLine(entity.ToString());
                    }
                }

                if (result == Actions.Clear)
                {
                    geometricEntitiesRepository.DeleteAll();
                }

            }
        }

        public bool TryReadTypeForActions(string enteredStr, out Actions type)
        {
            type = Actions.Exit;

            if (!Enum.TryParse(enteredStr, out type))
            {
                return false;
            }

            if (!Enum.IsDefined(type))
            {
                return false;
            }

            return true;
        }
        public void ValidateNumberForGeometricEntityTypes()
        {
            if (true)
            {
                PrintOnConsole.PrintGeometricEntityTypes();

                if (!TryReadTypeForGeometricEntityTypes(Console.ReadLine(), out GeometricEntityTypes result))
                {
                    return;
                }

                geometricEntitiesRepository.Add(CreateEntityByType(result));
                

            }
        }

        public bool TryReadTypeForGeometricEntityTypes(string enteredStr, out GeometricEntityTypes type)
        {

            if (!Enum.TryParse(enteredStr, out type))
            {
                return false;
            }

            if (!Enum.IsDefined(type))
            {
                return false;
            }

            return true;
        }


        public GeometricEntity CreateEntityByType(GeometricEntityTypes geometricFigure) => geometricFigure switch
        {
            GeometricEntityTypes.Circle => CreateEntities.CreateCircle(),
            GeometricEntityTypes.LineSegment => CreateEntities.CreateLineSegment(),
            GeometricEntityTypes.Rectangle => CreateEntities.CreateRectangle(),
            GeometricEntityTypes.Ring => CreateEntities.CreateRing(),
            GeometricEntityTypes.Triangle => CreateEntities.CreateTriangle(),
            GeometricEntityTypes.Point => CreateEntities.CreatePoint(),
            _ => throw new ArgumentException("There is no such figure."),
        };

    }
}

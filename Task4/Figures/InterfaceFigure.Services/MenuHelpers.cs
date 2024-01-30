using InterfaceFigure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class MenuHelpers
    {
        public static void PrintActions(IUserInteractor userInteractor)
        {
            userInteractor.PrintMessage("Выберите действие:\n\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Выход");
        }

        public static void PrintGeometricEntityTypes(IUserInteractor userInteractor)
        {
            userInteractor.PrintMessage("Выберите тип фигуры:\n\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка");
        }
    }
}

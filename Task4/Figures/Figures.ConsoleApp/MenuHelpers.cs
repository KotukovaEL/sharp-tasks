using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class MenuHelpers
    {
        public static void PrintActions()
        {
            Console.WriteLine("Выберите действие: \n\t 1. Добавить фигуру \n\t 2. Вывести фигуры \n\t 3. Очистить холст \n\t 4. Выход");
        }

        public static void PrintGeometricEntityTypes()
        {
            Console.WriteLine("Выберите тип фигуры: \n\t 1. Круг \n\t 2. Линия \n\t 3. Прямоугольник \n\t 4. Кольцо \n\t 5. Треугольник \n\t 6. Точка");
        }
    }
}

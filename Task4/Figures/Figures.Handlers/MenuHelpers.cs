namespace Figures.Handlers
{
    public class MenuHelpers
    {

        public static void PrintActions(IUserInteractor userInteractor)
        {
            userInteractor.PrintMessage("\t1. Добавить фигуру\n\t2. Вывести фигуры\n\t3. Очистить холст\n\t4. Сменить пользователя\n\t5. Выход");
        }

        public static void PrintGeometricEntityTypes(IUserInteractor userInteractor)
        {
            userInteractor.PrintMessage("\t1. Круг\n\t2. Линия\n\t3. Прямоугольник\n\t4. Кольцо\n\t5. Треугольник\n\t6. Точка");
        }
    }
}



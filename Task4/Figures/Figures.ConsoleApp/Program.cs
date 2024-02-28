using Figures.Model;
using Figures.Repositories;
using Figures.Services;
using System.Collections.Generic;

namespace Figures.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var interactor = new ConsoleUserInteractor();
            var entitiesCreator = new EntitiesCreator(interactor);
            var filePath = "Entities.txt";
            var context = new TxtDbContext(filePath);
            var userService = new UsersService("Users.txt", context);
            var logic = new FiguresAppLogic(interactor, entitiesCreator, userService);
            logic.Run();
        }
    }
}

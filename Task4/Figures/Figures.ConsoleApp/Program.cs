using Figures.Handlers;
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
            var usersRepository = new UsersRepository("Users.txt");
            var entitiesRepository = new GeometricEntitiesRepository("Entities.txt");

            var userService = new UsersService(entitiesRepository, usersRepository);

            var interactor = new ConsoleUserInteractor();
            var entitiesCreator = new EntitiesCreator(interactor);
            var handler = new FiguresAppHandler(interactor, entitiesCreator, userService);
            handler.Run();
        }
    }
}

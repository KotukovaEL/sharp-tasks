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
            var usersService = new UsersService();
            var logic = new FiguresAppLogic(interactor, entitiesCreator, usersService);
            logic.Run();
        }
    }
}

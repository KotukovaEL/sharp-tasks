﻿using Figures.Handlers;
using Figures.Model;
using Figures.Repositories;
using Figures.Repositories.Interface;
using Figures.Services;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace Figures.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var usersRepository = RepositoriesCreator.CreateUsersRepository("Users.txt");
            var entitiesRepository = RepositoriesCreator.CreateEntitiesRepository("Entities.txt");

            var userService = new UsersService(entitiesRepository, usersRepository);

            var interactor = new ConsoleUserInteractor();
            var entitiesCreator = new EntitiesCreator(interactor);
            var handler = new FiguresAppHandler(interactor, entitiesCreator, userService);
            handler.Run();
        }
    }
}

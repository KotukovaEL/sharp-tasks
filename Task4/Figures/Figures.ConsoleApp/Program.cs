﻿using Figures.Model;
using Figures.Repositories;
using Figures.Services;
using System;
using System.Collections.Generic;

namespace Figures.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var geometricEntitiesRepository = new GeometricEntitiesRepository();
            var interactor = new ConsoleUserInteractor();
            var entitiesCreator = new EntitiesCreator(interactor);
            var logic = new FiguresAppLogic(interactor, geometricEntitiesRepository, entitiesCreator);
            logic.Run();
        }
    }
}

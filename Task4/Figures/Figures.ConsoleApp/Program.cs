﻿using Figures.Model;
using Figures.Repositories;
using System;
using System.Collections.Generic;

namespace Figures.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logic = new FiguresAppLogic();
            logic.Run();
        }
    }
}

using Figures.Handlers;
using Figures.Services;
using System;

namespace Figures.ConsoleApp
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadStr()
        {
            return Console.ReadLine();
        }
    }
}

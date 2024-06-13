using System;
using TextAnalysis.Logic;

namespace TextAnalysis.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInteractor = new ConsoleUserInteractor();
            var logics = new Logics(userInteractor);
            logics.Run();
        }
    }
}

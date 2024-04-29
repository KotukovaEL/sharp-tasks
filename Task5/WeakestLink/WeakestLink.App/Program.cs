using Microsoft.VisualBasic;
using System;
using WeakestLink.Handlers;

namespace WeakestLink.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInteractor = new ConsoleUserInteractor();
            var handler = new WeakestLinkAppHandler(userInteractor);
            handler.Run();
        }
    }
}

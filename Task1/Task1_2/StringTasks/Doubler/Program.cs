using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Doubler
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var logic = new Logic();
            var app = new Application(logic);
            app.Run();
        }
    }
}
//var str = "написать программу, которая";
//var str1 = "описание";
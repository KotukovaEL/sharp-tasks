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
            var str = "написать программу, которая";
            var str1 = "описание";
            var value = Logic.DoubleSymbol(str, str1);
            Console.WriteLine(value);
        }
    }
}

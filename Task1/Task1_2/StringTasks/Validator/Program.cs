using System;
using System.Globalization;
using System.Linq;

namespace Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str = "dasddas adsa. d dcsd hg! hihih? sdf svcd scvds.";
            char[] endSigns = { '.', '!', '?' };
            var value = Logic.Validator(str, endSigns);
            Console.WriteLine(value);
        }      
    }
}
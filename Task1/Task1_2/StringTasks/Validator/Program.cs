using System;
using System.Globalization;
using System.Linq;

namespace Validator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logic = new Logic();
            var app = new Application(logic);
            app.Run();
        }      
    }
}
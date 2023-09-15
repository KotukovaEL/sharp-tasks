using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Averages
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            var logic = new Logic(app); 
            logic.Run();
            
            
        }
    }
}

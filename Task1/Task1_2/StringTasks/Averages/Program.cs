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
            var logic = new Logic(); 
            var app = new Application(logic);         
            app.Run();         
        }
    }
}
//"Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";
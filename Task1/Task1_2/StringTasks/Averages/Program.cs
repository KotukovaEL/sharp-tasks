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
            var textString = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";            
            Console.WriteLine(textString);
            var value = string.Format("{0:0.0}", Logic.AverageWordLength(textString));
            Console.WriteLine(value);
        }
    }
}

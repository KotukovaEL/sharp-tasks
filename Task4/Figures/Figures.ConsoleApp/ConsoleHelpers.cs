using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class ConsoleHelpers
    {
        public static double ReadDouble(string str)
        {
            double value;

            while (!double.TryParse(str, out value))
            {
                Console.WriteLine("Попробуй снова ввести");
                str = Console.ReadLine();
            }

            return value;
        }
    }
}

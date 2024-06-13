using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis.App
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintMessage(string message1, string message2, string message3)
        {
            Console.WriteLine(message1, message2, message3);
        }

        public string ReadStr()
        {
            return Console.ReadLine();
        }
    }
}

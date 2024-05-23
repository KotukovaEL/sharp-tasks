using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeakestLink.Handlers;

namespace WeakestLink.App
{
    public class ConsoleUserInteractor : IUserInteractor
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadStr()
        {
            return Console.ReadLine();
        }
    }
}

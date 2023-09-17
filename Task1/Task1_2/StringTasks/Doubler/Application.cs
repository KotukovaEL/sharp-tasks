using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubler
{
    public class Application
    {
        private readonly Logic _logic;

        public Application(Logic logic)
        {
            _logic = logic;
        }

        public void Run()
        {
            var str1 = PrintStr("1");
            var str2 = PrintStr("2");
            var sentence =  _logic.DoubleSymbol(str1, str2);
            Console.WriteLine(sentence);
        }

        public string PrintStr(string str)
        {
            Console.WriteLine($"Введите {str} строку: ");
            return Console.ReadLine(); ;
        }
    }
}

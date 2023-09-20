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
            var str1 = EnterStr("1");
            var str2 = EnterStr("2");
            var resultStr =  _logic.DoubleSymbol(str1, str2);
            Console.WriteLine(resultStr);
        }

        public string EnterStr(string str)
        {
            Console.WriteLine($"Введите {str} строку: ");
            return Console.ReadLine(); ;
        }
    }
}

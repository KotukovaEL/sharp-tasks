using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Averages
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
            var sentence = EnterSentence();
            var averageWordLength = string.Format("{0:0.0}", _logic.AverageWordLength(sentence));
            Console.WriteLine(averageWordLength);
        }

        public string EnterSentence()
        {
            Console.WriteLine("Введите предложение: ");
            return Console.ReadLine();
        }
    }
}

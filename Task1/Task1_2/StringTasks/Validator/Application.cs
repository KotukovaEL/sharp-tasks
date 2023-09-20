using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
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
            var numberWordsWithSmallLetter = _logic.Validator(sentence);
            Console.WriteLine(numberWordsWithSmallLetter);
        }

        public string EnterSentence()
        {
            Console.WriteLine("Введите предложение: ");
            return Console.ReadLine();
        }
    }
}

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
            PrintMessage();
            var sentence = ReadSentence();
            var numberWordsWithSmallLetter = _logic.Validator(sentence);
            Console.WriteLine(numberWordsWithSmallLetter);
        }

        public void PrintMessage()
        {
            Console.WriteLine("Введите предложение: ");
        }

        public string ReadSentence()
        {
            return Console.ReadLine();
        }
    }
}

﻿using System;
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
            PrintMessage();
            var sentence = ReadSentence();
            sentence = string.Format("{0:0.0}", _logic.AverageWordLength(sentence));
            Console.WriteLine(sentence);
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

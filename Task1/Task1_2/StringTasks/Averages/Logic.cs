using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Averages
{
    public class Logic
    {
        private readonly Application app;

        public Logic(Application app)
        {
            this.app = app;
        }

        public void Run()
        {
            app.PrintMessage();
            var sentence = app.ReadSentence();
            sentence = string.Format("{0:0.0}", AverageWordLength(sentence));
            Console.WriteLine(sentence);
        }

        private double AverageWordLength(string textString)
        {
            var separators = new [] { '@', '_', ',', '.', '!', '?', '^', ':', ';', '—', ' ', '-','\'','\\', '\"' };
            var words = textString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int wordsLengthSum = 0;

            foreach (string word in words)
            {
                wordsLengthSum += word.Length;
            }

            return wordsLengthSum / (double)words.Length;

        }




        
    }
}

//var textString = "Викентий хорошо отметил день рождения: покушал пиццу, посмотрел кино, пообщался со студентами в чате";
//Console.WriteLine(textString);
//var value = string.Format("{0:0.0}", Logic.AverageWordLength(textString));
//Console.WriteLine(value);
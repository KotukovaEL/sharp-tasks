using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Averages
{
    public class Logic
    {     
        public double AverageWordLength(string textString)
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



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Averages
{
    public static class Logic
    {
        public static double AverageWordLength(string textString)
        {
            char[] charsToRemove = { '@', '_', ',', '.', '!', '?', '^', ':', ';', '—', ' ', '-','\'','\\', '\"' };
            string[] editedText = textString.Split(charsToRemove, StringSplitOptions.RemoveEmptyEntries);
            int countWords = 0;
            int countLettersInWord = 0;

            foreach (string c in editedText)
            {
                countWords++;
                countLettersInWord += c.Length;
            }

            double averageLength = (countLettersInWord / (double)countWords);
            return averageLength;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowerCase
{
    public static class Logic
    {
        public static int CountWordsWithSmallLetter(string str)
        {
            string[] editedText = str.Split(new[] {' ', ',', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int countWords = 0;

            for (int i = 0; i < editedText.Length; i++)
            {
                if (editedText[i] == editedText[i].ToString().ToLower())
                {
                    countWords++;
                }

            }

            return countWords;
        }
    }
}

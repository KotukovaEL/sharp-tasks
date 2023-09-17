using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowerCase
{
    public  class Logic
    {
        public int CountWordsWithSmallLetter(string str)
        {
            var words = str.Split(new[] {' ', ',', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsCount = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (char.IsLower(words[i][0]))
                {
                    wordsCount++;
                }
            }

            return wordsCount;
        }
    }
}

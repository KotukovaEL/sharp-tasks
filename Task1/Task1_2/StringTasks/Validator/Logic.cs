using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    public static class Logic
    {
        public static string Validator(string str, char[] endSigns)
        {
            char[] separators = { ' ' };
            string[] words = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var results = new List<string>();
            bool isSentenceStart = true;

            foreach (var word in words)
            {
                var wordToAdd = word;

                if (isSentenceStart)
                {
                    wordToAdd = wordToAdd.Substring(0, 1).ToUpper() + wordToAdd.Substring(1);
                    isSentenceStart = false;
                }

                if (IsSentenceEnd(word, endSigns))
                {
                    isSentenceStart = true;  
                                      
                }

                results.Add(wordToAdd);
            }

            return string.Join(" ", results);
        }

        public static bool IsSentenceEnd(string str, char[] endSigns)
        {
            foreach (var endSign in endSigns)
            {
                if (str.Contains(endSign))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

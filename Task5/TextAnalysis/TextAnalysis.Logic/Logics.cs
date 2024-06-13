using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using TextAnalysis.App;

namespace TextAnalysis.Logic
{
    public class Logics
    {
        private readonly IUserInteractor _userInteractor;

        public Logics(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public void Run()
        {
            _userInteractor.PrintMessage("Введите текст");
            var text = _userInteractor.ReadStr().ToLower();


            var separators = new[] { ',', ':', ';', '-', '"', '!', '?', '.', ' ', '\t', '\n' };
            var words = new List<string>(text.Split(separators, StringSplitOptions.RemoveEmptyEntries)); 
            var wordsMap = new Dictionary<string, int>();
            
            AddWordsInMap(words, wordsMap);
            ShowWords(wordsMap);
            WriteConclusion(wordsMap);
        }

        private void AddWordsInMap(List<string> words, Dictionary<string, int> wordsMap)
        {
            var count = 0;

            foreach (var word in words)
            {
                for (int i = 0; i < words.Count; i++)
                {
                    if (word == words[i])
                    {
                        count++;
                        wordsMap.Remove(words[i]);
                    }
                }
                wordsMap.Add(word, count);
                count = 0;
            }
        }

        private void ShowWords(Dictionary<string, int> wordsMap)
        {
            _userInteractor.PrintMessage("\t{0,-20} | {1,5}\n", "Слово", "Количество повторений");

            foreach (var word in wordsMap)
            {
                _userInteractor.PrintMessage("\t{0,-20} | {1,5}", word.Key, word.Value.ToString());
            }
        }

        private void WriteConclusion(Dictionary<string, int> wordsMap)
        {
            int wordCount = 0;
            int numberRepetitions = 1;
            int countOneRepetition = 0;

            foreach (var word in wordsMap.Values)
            {
                if (numberRepetitions == 1)
                {
                    countOneRepetition++;
                }

                wordCount += word;
            }

            if (countOneRepetition > wordCount / 2)
            {
                _userInteractor.PrintMessage("\tТекст интересный");
            }
            else
            {
                _userInteractor.PrintMessage("\tТекст не интересный");
            }
        }
    }
}

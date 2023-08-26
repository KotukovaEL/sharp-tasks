using System;

namespace LowerCase
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var str = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звездные Войны";
            var value = Logic.CountWordsWithSmallLetter(str);
            Console.WriteLine(value);
        }
    }
}

using System;

namespace LowerCase
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var logic = new Logic();
            var app = new Application(logic);
            app.Run();
        }
    }
}
// var str = "Антон хорошо начал утро: послушал Стинга, выпил кофе и посмотрел Звездные Войны";
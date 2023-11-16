using AlternativeDateTime;
using System;

namespace Application
{
    public class App
    {
        public void Run()
        {
            var td5 = new CustomDateTime(2023, 01, 2, 23, 47, 12);
            //var td6 = new TimeSpan(28, 14, 5, 12);
            var td6 = new CustomTimeSpan(234, 12, 44, 0);
            Console.WriteLine(td5 - td6);


            var td7 = new DateTime(2023, 01, 2, 23, 47, 12);
            //var td8 = new TimeSpan(28, 14, 5, 12);
            var td8 = new TimeSpan(234, 12, 44, 0);
            Console.WriteLine(td7 - td8);
        }
    }
}
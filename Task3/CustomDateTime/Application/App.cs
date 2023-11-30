using AlternativeDateTime;
using System;

namespace Application
{
    public class App
    {
        public void Run()
        {
            var td = new CustomDateTime(2023, 01, 01, 18, 49, 12);
            var ts = new CustomTimeSpan(32, 23, 49, 12);
            Console.WriteLine(td+ts);

            var td1 = new DateTime(2023, 01, 01, 18, 49, 12);
            var ts1 = new TimeSpan(32, 23, 49, 12);
            Console.WriteLine(td1 + ts1);
        }
    }
}
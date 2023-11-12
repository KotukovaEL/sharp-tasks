using AlternativeDateTime;
using System;

namespace Application
{
    public class App
    {
        public void Run()
        {
            //var dateTime = new CustomDateTime(2023, 03, 2, 16, 12, 00);
            //var dateTime2 = new CustomDateTime(2024, 01, 21, 23, 15, 40);
            //var result = dateTime - dateTime2;
            //Console.WriteLine(result);

            var ts1 = new CustomDateTime(2023, 5, 10, 10, 47, 12);
            var ts2 = new CustomDateTime(2023, 2, 28, 14, 5, 12);
            Console.WriteLine( ts1 - ts2);

            var ts5 = new CustomDateTime(2022, 5, 10, 10, 47, 12);
            var ts6 = new CustomDateTime(2023, 2, 28, 14, 5, 12);
            Console.WriteLine(ts5 - ts6);

            //var dt = new DateTime(2023, 03, 2, 16, 12, 00);
            //var dt2 = new DateTime(2024, 01, 21, 23, 15, 40);
            //Console.WriteLine(dt - dt2);

            var td3 = new DateTime(2022, 5, 10, 10, 47, 12);
            var td4 = new DateTime(2023, 2, 28, 14, 5, 12);
            //var td4 = new TimeSpan(-12, -8, -44, 0);
            Console.WriteLine(td3 - td4);
        }
    }
}
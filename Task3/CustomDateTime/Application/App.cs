using AlternativeDateTime;
using System;

namespace Application
{
    public class App
    {
        public void Run()
        {

            //var ts1 = new CustomDateTime(2023, 5, 10, 10, 47, 12);
            //var ts2 = new CustomTimeSpan(-28, -14, -5, -12);
            //Console.WriteLine(ts1 + ts2);

            var ts1 = new CustomDateTime(2023, 01, 02, 10, 5, 12);
            var ts2 = new CustomTimeSpan(12, 8, 44, 0);
            Console.WriteLine(ts1 + ts2);


            //var td3 = new DateTime(2023, 5, 10, 10, 47, 12);
            //var td4 = new TimeSpan(-28, -14, -5, -12);
            //var td4 = new TimeSpan(-12, -8, -44, 0);
            //Console.WriteLine(td3 + td4);

            var td3 = new DateTime(2023, 01, 02, 10, 5, 12);
            var td4 = new TimeSpan(12, 8, 44, 0);
            //var td4 = new TimeSpan(-12, -8, -44, 0);
            Console.WriteLine(td3 + td4);

            //var td6 = CustomTimeSpan.FromSeconds(447);
            //var td5 = TimeSpan.FromSeconds(447);
            //Console.WriteLine(td5);
            //Console.WriteLine(td6);

            var ts5 = new CustomDateTime(2023, 5, 10, 10, 47, 12);
            var ts6 = new CustomTimeSpan(28, 14, 5, 12);
            Console.WriteLine(ts5 + ts6);

            var td7 = new DateTime(2023, 5, 10, 10, 47, 12);
            var td8 = new TimeSpan(28, 14, 5, 12);
            //var td4 = new TimeSpan(-12, -8, -44, 0);
            Console.WriteLine(td7 + td8);
        }
    }
}
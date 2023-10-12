using AlternativeString;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class App
    {
        public void Run()
        {
            var customString1 = new CustomString("geeksForForForGeeks");
            var customString2 = new CustomString("For");
            var customString4 = new CustomString("Hello");
            //var splitedList = customString1.Split(new[] { ',', ';', ' ' });

            //foreach (var value in splitedList)
            //{
            //    Console.Write(value);
            //}
           
            Console.WriteLine(customString1.Replace(customString2, customString4));

            //var str = "dsfsd";
            //var str2 = str.IndexOf()
        }
    }
}

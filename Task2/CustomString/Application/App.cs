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
            var customString1 = new CustomString("geeks,For,Geeks");
            var customString2 = new CustomString("Geeks");
            var customString4 = new CustomString("sdsf");
            var splitedList = customString1.Split(new[] { ',', ';', ' ' });

            foreach (var value in splitedList)
            {
                Console.Write(value);
            }
        }
    }
}

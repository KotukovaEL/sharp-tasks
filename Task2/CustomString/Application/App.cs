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
            var customString1 = new CustomString("a bcde ft");
            var customString2 = new CustomString("ac");
            var customString4 = new CustomString("sdsf");

            Console.WriteLine(customString1.Split());
            //var str = "GeeksForGeeks";
            //var str2 = str.Split();
            //Console.WriteLine(str2);
        }
    }
}

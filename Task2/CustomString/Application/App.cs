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
          
            Console.WriteLine(customString1.Replace(customString2, customString4));

        }
    }
}

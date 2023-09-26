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
            var customString1 = new CustomString("abcdeft");
            var customString2 = new CustomString("dfghjkt");
            Console.WriteLine(customString1.Equals(customString2));
            Console.WriteLine(customString1.ConcatString(customString2));
            Console.WriteLine(customString1.IndexOf('k'));
            Console.WriteLine(customString1.ToCharArray());
            Console.WriteLine(customString1.FindVowelsCount());
            Console.WriteLine(customString1.DeleteVowelLetters());


        }
    }
}

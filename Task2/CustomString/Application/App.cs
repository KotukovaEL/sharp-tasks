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
            var customString3 = new CustomString("5");
            var customString4 = new CustomString("sdsf");
            customString4[3] = 'h';
            //var result = (int)customString3;
            Console.WriteLine(customString1.Equals(customString2));
            Console.WriteLine(customString1.Concat(customString2));
            Console.WriteLine(customString1.IndexOf('k'));
            Console.WriteLine(customString1.ToCharArray());
            Console.WriteLine(customString1.FindVowelsCount());
            Console.WriteLine(customString1.DeleteVowelLetters());
            Console.WriteLine(customString1.CompareTo(customString2));
            Console.WriteLine(customString1.LastIndexOf('e'));
            Console.WriteLine(customString1 + customString2);
            Console.WriteLine(customString1 == customString2);
            Console.WriteLine(customString1 != customString2);
            Console.WriteLine(customString4[3]);
            //Console.WriteLine(customString2 += customString1);
            //Console.WriteLine(result.GetType());
        }
    }
}

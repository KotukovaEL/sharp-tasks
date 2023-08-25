using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubler
{
    public static class Logic
    {
        public static string SymbolDoubling(string str, string str1)
        {
            var newString = new StringBuilder();

            foreach (char i in str)
            {
                var boolValue = str1.Contains(i);
                newString.Append(i);

                if (boolValue)
                {
                    newString.Append(i);
                }
            }

            return newString.ToString();
        }
    }
}

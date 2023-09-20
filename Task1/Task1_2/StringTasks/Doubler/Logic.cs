using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubler
{
    public class Logic
    {
        public string DoubleSymbol(string firstStr, string secondStr)
        {
            var sb = new StringBuilder();

            foreach (var letter in firstStr)
            {
                sb.Append(letter);

                if (secondStr.Contains(letter))
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
    }
}

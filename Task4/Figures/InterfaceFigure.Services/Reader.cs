using InterfaceFigure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class Reader
    {
        public static double ReadDouble(IUserInteractor userInteractor)
        {
            do
            {
                string str = userInteractor.ReadStr();

                if (double.TryParse(str, out var value))
                {
                    return value;
                }

                userInteractor.PrintMessage("Попробуй снова ввести");
            }
            while (true);
        }
    }
}

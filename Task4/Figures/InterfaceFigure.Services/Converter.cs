using InterfaceFigure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.ConsoleApp
{
    public class Converter
    {
        public static double ReadDouble(string str, IUserInteractor userInteractor)
        {
            double value;

            while (!double.TryParse(str, out value))
            {
                userInteractor.PrintMessage("Попробуй снова ввести");
                str = userInteractor.ReadValue();
            }

            return value;
        }
    }
}

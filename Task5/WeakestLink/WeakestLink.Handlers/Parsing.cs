using System;
using System.Collections.Generic;
using System.Text;

namespace WeakestLink.Handlers
{
    public static class Parsing
    {
        public static int IntParse(IUserInteractor userInteractor, string numberPeople)
        {
            while (true)
            {
                if (!int.TryParse(numberPeople, out var number))
                {
                    userInteractor.PrintMessage("Попытайся заново");
                    userInteractor.ReadStr();
                }

                return number;
            }
        }
    }
}

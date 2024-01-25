using Figures.Model;
using System;
using System.Collections.Generic;

namespace InterfaceFigure.Services
{
    public interface IUserInteractor
    {
        void PrintMessage(string message);
        string ReadValue();
    }
}

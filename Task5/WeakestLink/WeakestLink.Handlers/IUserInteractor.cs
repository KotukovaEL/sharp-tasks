using System;

namespace WeakestLink.Handlers
{
    public interface IUserInteractor
    {
        void PrintMessage(string message);
        string ReadStr();
    }
}

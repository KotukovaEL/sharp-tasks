using Figures.Model;

namespace Figures.Common.Interfaces
{
    public interface IUsersRepository
    {
        User GetUser(string name);
        void TryAdd(string name);
    }
}

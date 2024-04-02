using Figures.Model;

namespace Figures.Common.Interfaces
{
    public interface IUsersRepository
    {
        User GetUser(string name);
        void TryAdd(string name);
        void AddFigure(string name, int figureId);
        User GetByKey(string name);
    }
}

using System.IO;

namespace Figures.Repositories
{
    public interface ISourceIO
    {
        TextWriter CreateWriter();
        string[] ReadAllLines();
    }
}
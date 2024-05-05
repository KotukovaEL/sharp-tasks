using WeakestLink.Handlers;
using WeakestLink.Handlers.NodesImplementation;

namespace WeakestLink.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInteractor = new ConsoleUserInteractor();
            var weakestLinkGame = new WeakestLinkGame(userInteractor);
            var handler = new WeakestLinkAppHandler(userInteractor, weakestLinkGame);
            handler.Run();
        }
    }
}

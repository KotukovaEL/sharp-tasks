using WeakestLink.Handlers;

namespace WeakestLink.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInteractor = new ConsoleUserInteractor();
            var fillingList = new FillingList();
            var handler = new WeakestLinkAppHandler(userInteractor, fillingList);
            handler.Run();
        }
    }
}

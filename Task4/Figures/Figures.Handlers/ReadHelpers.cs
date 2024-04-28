namespace Figures.Handlers
{
    public class ReadHelpers
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
    

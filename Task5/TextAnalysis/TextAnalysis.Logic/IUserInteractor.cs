namespace TextAnalysis.App
{
    public interface IUserInteractor
    {
        void PrintMessage(string message);
        void PrintMessage(string message1, string message2, string message3);
        string ReadStr();
    }
}
namespace LoggerApplication.Models.Interfaces
{
    public interface ILogger
    {
        void Log(IError error);
    }
}
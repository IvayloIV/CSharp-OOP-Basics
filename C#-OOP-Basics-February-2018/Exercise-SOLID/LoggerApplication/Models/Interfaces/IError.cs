namespace LoggerApplication.Models.Interfaces
{
    public interface IError : ILevelable
    {
        string DataTime { get; }
        
        string Message { get; }
    }
}
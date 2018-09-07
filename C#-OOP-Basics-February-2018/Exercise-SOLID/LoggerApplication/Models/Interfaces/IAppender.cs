namespace LoggerApplication.Models.Interfaces
{
    public interface IAppender : ILevelable
    {
        int MessagesCount { get; }    
    
        ILayout Layout { get; }

        void Append(IError error);
    }
}
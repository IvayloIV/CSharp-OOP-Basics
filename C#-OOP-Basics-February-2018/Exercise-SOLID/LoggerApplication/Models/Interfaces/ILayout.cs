namespace LoggerApplication.Models.Interfaces
{
    public interface ILayout
    {
        string Format(IError error);
    }
}
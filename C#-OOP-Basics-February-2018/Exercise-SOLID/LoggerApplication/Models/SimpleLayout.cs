using LoggerApplication.Models.Interfaces;

namespace LoggerApplication.Models
{
    public class SimpleLayout : ILayout
    {
        private const string StringFormat = "{0} - {1} - {2}";

        public string Format(IError error)
        {
            return string.Format(StringFormat, error.DataTime, error.Level, error.Message);
        }
    }
}
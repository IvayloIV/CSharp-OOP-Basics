using LoggerApplication.Models.Interfaces;
using System;

namespace LoggerApplication.Models.Factories
{
    public class AppenderFactory
    {
        public IAppender Create(ILayout layout, string errorStr, string appenderType)
        {
            var isValidError = Enum.TryParse(errorStr, out ErrorLevel error);
            switch (appenderType)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, error);
                case "FileAppender":
                    return new FileAppender(layout, error);
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
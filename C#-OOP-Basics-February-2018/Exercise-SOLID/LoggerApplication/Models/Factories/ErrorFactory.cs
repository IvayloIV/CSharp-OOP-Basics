using LoggerApplication.Models.Interfaces;
using System;

namespace LoggerApplication.Models.Factories
{
    public class ErrorFactory
    {
        public IError GetError(string errorStr, string date, string messsage)
        {
            var isValid = Enum.TryParse(errorStr, out ErrorLevel errorLevel);
            return new Error(date, errorLevel, messsage);
        }
    }
}
using LoggerApplication.Models.Interfaces;

namespace LoggerApplication.Models
{
    public class Error : IError
    {
        public Error(string dataTime, ErrorLevel level, string message)
        {
            this.DataTime = dataTime;
            this.Message = message;
            this.Level = level;
        }    

        public string DataTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
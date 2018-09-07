using LoggerApplication.Models.Interfaces;

namespace LoggerApplication.Models
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.MessagesCount = 0;
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = new LogFile();
        }


        private ILogFile logFile;

        public int MessagesCount { get; private set; }

        public ILayout Layout { get; private set; }

        public ErrorLevel Level { get; private set; }

        public void Append(IError error)
        {
            string formatedError = this.Layout.Format(error);
            this.logFile.WriteToFile(formatedError);
            this.MessagesCount++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
            $"Report level: {this.Level.ToString()}, Messages appended: {this.MessagesCount}, File size: {this.logFile.Size}";
        }
    }
}

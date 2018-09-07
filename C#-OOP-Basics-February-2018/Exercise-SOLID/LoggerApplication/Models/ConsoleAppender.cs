using LoggerApplication.Models.Interfaces;
using System;

namespace LoggerApplication.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesCount = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesCount { get; private set; }

        public void Append(IError error)
        {
            string formatedError = this.Layout.Format(error);
            Console.WriteLine(formatedError);
            this.MessagesCount++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
            $"Report level: {this.Level.ToString()}, Messages appended: {this.MessagesCount}";
        }
    }
}
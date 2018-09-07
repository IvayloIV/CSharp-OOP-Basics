using LoggerApplication.Models.Interfaces;
using System.Text;

namespace LoggerApplication.Models
{
    public class XmlLayout : ILayout
    {
        public string Format(IError error)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<log>")
                .AppendLine($"  <date>{error.DataTime}</date>")
                .AppendLine($"  <level>{error.Level.ToString()}</level>")
                .AppendLine($"  <message>{error.Message}</message>")
                .AppendLine($"</log>");

            return builder.ToString().TrimEnd();
        }
    }
}
using LoggerApplication.Models.Interfaces;
using System;
using System.IO;

namespace LoggerApplication.Models
{
    public class LogFile : ILogFile
    {
        public LogFile()
        {
            this.Size = 0;
        }    

        public string Path => "./log.txt";

        public int Size { get; private set; }

        public void WriteToFile(string text)
        {
            var currentSize = 0;
            for (int i = 0; i < text.Length; i++)
            {
                currentSize += text[i];
            }

            this.Size += currentSize;

            File.AppendAllText(this.Path, text + Environment.NewLine);
        }
    }
}
using LoggerApplication.Models;
using LoggerApplication.Models.Factories;
using LoggerApplication.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var appenders = CreateAppenders();
            ILogger logger = new Logger(appenders);

            ReadAndAddMessages(logger);
            PrintLoggerInfo(appenders);
        }

        private static void ReadAndAddMessages(ILogger logger)
        {
            var errorFactory = new ErrorFactory();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split("|");
                var errorStr = tokens[0];
                var date = tokens[1];
                var message = tokens[2];

                var currentError = errorFactory.GetError(errorStr, date, message);

                logger.Log(currentError);
            }
        }

        private static void PrintLoggerInfo(List<IAppender> appenders)
        {
            Console.WriteLine($"Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }

        private static List<IAppender> CreateAppenders()
        {
            var appenders = new List<IAppender>();
            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory();

            int appendCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appendCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var appenderType = tokens[0];
                var layoutType = tokens[1];
                var errorStr = "INFO";

                if (tokens.Length == 3)
                {
                    errorStr = tokens[2];
                }

                ILayout layout = layoutFactory.Create(layoutType);
                IAppender appender = appenderFactory.Create(layout, errorStr, appenderType);

                appenders.Add(appender);
            }

            return appenders;
        }
    }
}
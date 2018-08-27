using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studentTokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentTokens[0], studentTokens[1], studentTokens[2]);
                var workerTokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(workerTokens[0], workerTokens[1],
                    decimal.Parse(workerTokens[2]), decimal.Parse(workerTokens[3]));
                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
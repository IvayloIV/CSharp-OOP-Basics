using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                try
                {
                    var tokens = line.Split(new[] { " ", ", "}, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = tokens[0];
                    var items = tokens.Skip(1).ToArray();
                    switch (command)
                    {
                        case "Push":
                            stack.Push(items);
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                    }
                }
                catch (ArgumentException err)
                {
                    Console.WriteLine(err.Message);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
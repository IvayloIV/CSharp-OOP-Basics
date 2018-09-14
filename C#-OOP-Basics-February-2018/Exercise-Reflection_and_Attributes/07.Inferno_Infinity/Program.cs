using System;
using System.Linq;
using System.Reflection;

namespace _07.Inferno_Infinity
{
    class Program
    {
        static void Main(string[] args)
        {
            var infernoBuilder = new InfernoBuilder();

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split(";");
                var command = tokens[0];
                tokens = tokens.Skip(1).ToArray();
                InvokeCommand(infernoBuilder, tokens, command);
            }
        }

        private static void InvokeCommand(InfernoBuilder infernoBuilder, string[] tokens, string command)
        {
            var type = typeof(InfernoBuilder);
            var method = type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(a => a.Name == command);

            method.Invoke(infernoBuilder, new object[] { tokens });
        }
    }
}
using System;
using System.Linq;
using System.Reflection;

namespace _08.Create_Custom_Class_Attribute
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

            if (method == null)
            {
                PrintAttribute(command);
            }
            else
            {
                method.Invoke(infernoBuilder, new object[] { tokens });
            }
        }

        private static void PrintAttribute(string command)
        {
            var attrs = typeof(Weapon).GetCustomAttributes(typeof(ProjectAttribute), true);
            foreach (ProjectAttribute attr in attrs)
            {
                Console.WriteLine(FindCommandAttribute(command, attr));
            }
        }

        private static string FindCommandAttribute(string command, ProjectAttribute attr)
        {
            switch (command)
            {
                case "Author":
                    return $"Author: {attr.Author}";
                case "Revision":
                    return $"Revision: {attr.Revision}";
                case "Description":
                    return $"Class description: {attr.Description}";
                case "Reviewers":
                    return $"Reviewers: {string.Join(", ", attr.Reviewers)}";
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }
    }
}
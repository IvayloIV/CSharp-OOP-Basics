using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> collection = null;
        string line;
        while ((line = Console.ReadLine()) != "END")
        {
            try
            {
                var tokens = line.Split().ToList();
                var command = tokens[0];
                tokens = tokens.Skip(1).ToList();
                switch (command)
                {
                    case "Create":
                        collection = new ListyIterator<string>(tokens);
                        break;
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "Print":
                        collection.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                }
            }
            catch (ArgumentException err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
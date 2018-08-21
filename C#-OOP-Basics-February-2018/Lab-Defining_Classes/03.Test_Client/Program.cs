using System;
using System.Collections.Generic;

namespace _03.Test_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Dictionary<int, BankAccount>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                var tokens = input.Split();
                var command = tokens[0];
                var id = int.Parse(tokens[1]);
                switch (command)
                {
                    case "Create":
                        if (!book.ContainsKey(id))
                        {
                            book[id] = new BankAccount() { Id = id};
                        }
                        else
                        {
                            Console.WriteLine($"Account already exists");
                        }
                        break;
                    case "Deposit":
                        if (CheckForId(book, id))
                        {
                            book[id].Deposit(decimal.Parse(tokens[2]));
                        }
                        break;
                    case "Withdraw":
                        if (CheckForId(book, id))
                        {
                            book[id].Withdraw(decimal.Parse(tokens[2]));
                        }
                        break;
                    case "Print":
                        if (CheckForId(book, id))
                        {
                            Console.WriteLine(book[id]);
                        }
                        break;
                }
            }
        }

        private static bool CheckForId(Dictionary<int, BankAccount> book, int id)
        {
            if (!book.ContainsKey(id))
            {
                Console.WriteLine($"Account does not exist");
                return false;
            }
            return true;
        }
    }
}

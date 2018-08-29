using System;
using System.Collections.Generic;

namespace _08.Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            var soldiers = new List<Soldier>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                try
                {
                    var tokens = command.Split();
                    Soldier newSoldier = SoldierFactory.FindSoldier(tokens, soldiers);
                    soldiers.Add(newSoldier);
                    Console.WriteLine(newSoldier);
                }
                catch (ArgumentException) { }
            }
        }
    }
}
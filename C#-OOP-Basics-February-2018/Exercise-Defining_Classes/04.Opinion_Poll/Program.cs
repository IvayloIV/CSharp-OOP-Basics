using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Opinion_Poll
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split();
                people.Add(new Person(tokens[0], int.Parse(tokens[1])));
            }
            people.Where(a => a.Age > 30)
                .OrderBy(a => a.Name)
                .ToList()
                .ForEach(e => Console.WriteLine($"{e.Name} - {e.Age}")); 
        }
    }
}
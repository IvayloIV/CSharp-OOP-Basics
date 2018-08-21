using System;

namespace _03.Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                family.AddMember(new Person(line[0], int.Parse(line[1])));
            }
            var oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
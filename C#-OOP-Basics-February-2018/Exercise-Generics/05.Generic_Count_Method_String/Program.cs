using System;
using System.Collections.Generic;

namespace _05.Generic_Count_Method_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<string>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var item = Console.ReadLine();
                collection.Add(item);
            }

            var elemenetForCompare = Console.ReadLine();
            var box = new Box<string>(elemenetForCompare);

            Console.WriteLine(Compare(collection, box.Value));
        }

        public static int Compare<T>(IList<T> items, T elementCompare)
            where T : IComparable<T>
        {
            var counter = 0;

            foreach (var item in items)
            {
                if (elementCompare.CompareTo(item) < 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
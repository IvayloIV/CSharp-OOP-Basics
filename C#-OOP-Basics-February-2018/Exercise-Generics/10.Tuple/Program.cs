using System;

namespace _10.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split();
            var fullName = line1[0] + " " + line1[1];
            var address = line1[2];
            var tuple1 = new Tuple<string, string>(fullName, address);
            Console.WriteLine(tuple1);

            var line2 = Console.ReadLine().Split();
            var name = line2[0];
            var litersOfBeer = int.Parse(line2[1]);
            var tuple2 = new Tuple<string, int>(name, litersOfBeer);
            Console.WriteLine(tuple2);

            var line3 = Console.ReadLine().Split();
            var intValue = int.Parse(line3[0]);
            var doubleValue = double.Parse(line3[1]);
            var tuple3 = new Tuple<int, double>(intValue, doubleValue);
            Console.WriteLine(tuple3);
        }
    }
}
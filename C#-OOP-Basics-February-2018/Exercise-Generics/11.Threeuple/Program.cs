using System;

namespace _11.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split();
            var fullName = line1[0] + " " + line1[1];
            var address = line1[2];
            var town = line1[3];
            var tuple1 = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(tuple1);

            var line2 = Console.ReadLine().Split();
            var name1 = line2[0];
            var litersOfBeer = int.Parse(line2[1]);
            var drunkOrNot = line2[2] == "drunk";
            var tuple2 = new Threeuple<string, int, bool>(name1, litersOfBeer, drunkOrNot);
            Console.WriteLine(tuple2);

            var line3 = Console.ReadLine().Split();
            var name2 = line3[0];
            var accountBalance = double.Parse(line3[1]);
            var bankName = line3[2];
            var tuple3 = new Threeuple<string, double, string>(name2, accountBalance, bankName);
            Console.WriteLine(tuple3);
        }
    }
}
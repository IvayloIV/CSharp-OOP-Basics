using System;

namespace _04.Random_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new RandomList { "1","2", "3", "4","5" };
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
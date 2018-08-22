using System;

namespace _01.Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizeOfRhombus = int.Parse(Console.ReadLine());
            for (int counter = 1; counter <= sizeOfRhombus; counter++)
            {
                PrintRow(counter, sizeOfRhombus);
            }
            for (int counter = sizeOfRhombus - 1; counter > 0; counter--)
            {
                PrintRow(counter, sizeOfRhombus);
            }
        }

        private static void PrintRow(int starsCount, int sizeOfRhombus)
        {
            for (int counter = 0; counter < sizeOfRhombus - starsCount; counter++)
            {
                Console.Write(" ");
            }
            for (int counter = 1; counter < starsCount; counter++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("*");
        }
    }
}
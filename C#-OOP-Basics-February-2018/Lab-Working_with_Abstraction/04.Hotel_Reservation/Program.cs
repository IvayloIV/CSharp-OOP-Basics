using System;

namespace _04.Hotel_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            PriceCalculator priceCalc = new PriceCalculator(input);
            var sum = priceCalc.CalculatePrice();
            Console.WriteLine(sum.ToString("F2"));
        }
    }
}
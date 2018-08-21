using System;

namespace _05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstDateStr = Console.ReadLine();
            var secondDateStr = Console.ReadLine();
            var date = new DateModifier();
            date.CalculateDiff(firstDateStr, secondDateStr);
            Console.WriteLine(date.Different);
        }
    }
}
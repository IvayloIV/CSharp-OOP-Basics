using System;

class Program
{
    static void Main(string[] args)
    {
        var driverName = Console.ReadLine();
        ICar car = new Ferrari(driverName);
        Console.WriteLine(car);
    }
}

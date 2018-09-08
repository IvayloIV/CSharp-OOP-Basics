using System;

class Program
{
    static void Main(string[] args)
    {
        var scale = new Scale<string>("Pesho", "Pesho");
        Console.WriteLine(scale.GetHeavier());
    }
}
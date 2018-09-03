using System;
using System.Collections.Generic;

public static class DriverFactory
{
    public static Driver CreateDriver(List<string> tokens)
    {
        var type = tokens[0];
        var name = tokens[1];
        var hp = int.Parse(tokens[2]);
        var fuelAmount = double.Parse(tokens[3]);
        var tyre = TyreFactory.CreateTyre(tokens);
        var car = new Car(hp, fuelAmount, tyre);
        switch (type)
        {
            case "Aggressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                throw new ArgumentException("Invalid type of driver!");
        }
    }
}
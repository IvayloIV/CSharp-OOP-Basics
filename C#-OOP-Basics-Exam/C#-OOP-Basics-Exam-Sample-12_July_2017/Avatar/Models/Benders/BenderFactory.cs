using System;
using System.Collections.Generic;

public class BenderFactory
{
    public Bender CreateBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParameter = double.Parse(benderArgs[3]);
        switch (type)
        {
            case "Air":
                return new AirBender(name, power, secondaryParameter);
            case "Water":
                return new WaterBender(name, power, secondaryParameter);
            case "Fire":
                return new FireBender(name, power, secondaryParameter);
            case "Earth":
                return new EarthBender(name, power, secondaryParameter);
            default:
                throw new ArgumentException("Invalid bender type!");
        }
    }
}
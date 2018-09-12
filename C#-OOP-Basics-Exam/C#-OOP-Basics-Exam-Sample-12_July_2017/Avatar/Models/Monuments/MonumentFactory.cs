using System;
using System.Collections.Generic;

public class MonumentFactory
{
    public Monument CreateMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            case "Fire":
                return new FireMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            default:
                throw new ArgumentException("Invalid monument type!");
        }
    }
}

using System;
using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre CreateTyre(List<string> tokens)
    {
        var tyreType = tokens[4];
        var tyreHardness = double.Parse(tokens[5]);
        switch (tyreType)
        {
            case "Hard":
                return new HardTyre(tyreHardness);
            case "Ultrasoft":
                return new UltrasoftTyre(tyreHardness, double.Parse(tokens[6]));
            default:
                throw new ArgumentException("Invalid tyre type!");
        }
    }
}
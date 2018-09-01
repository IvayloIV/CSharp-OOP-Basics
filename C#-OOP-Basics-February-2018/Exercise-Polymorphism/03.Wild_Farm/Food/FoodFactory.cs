using System;

public static class FoodFactory
{
    public static Food GetFood(string[] tokens)
    {
        var type = tokens[0];
        var quantity = int.Parse(tokens[1]);
        switch (type)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Meat":
                return new Meat(quantity);
            case "Seeds":
                return new Seeds(quantity);
            default:
                throw new ArgumentException("Invalid food!");
        }
    }
}
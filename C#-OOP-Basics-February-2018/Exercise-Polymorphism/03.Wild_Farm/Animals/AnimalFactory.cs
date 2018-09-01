using System;

public static class AnimalFactory
{
    public static Animal GetAnimal(string[] tokens)
    {
        var type = tokens[0];
        var name = tokens[1];
        var weight = double.Parse(tokens[2]);
        switch (type)
        {
            case "Owl":
                var owlWingSize = double.Parse(tokens[3]);
                return new Owl(name, weight, owlWingSize);
            case "Hen":
                var henWingSize = double.Parse(tokens[3]);
                return new Hen(name, weight, henWingSize);
            case "Mouse":
                var mouseLivingRegion = tokens[3];
                return new Mouse(name, weight, mouseLivingRegion);
            case "Dog":
                var dogLivingRegion = tokens[3];
                return new Dog(name, weight, dogLivingRegion);
            case "Cat":
                var catLivingRegion = tokens[3];
                var catBreed = tokens[4];
                return new Cat(name, weight, catLivingRegion, catBreed);
            case "Tiger":
                var tigerLivingRegion = tokens[3];
                var tigerBreed = tokens[4];
                return new Tiger(name, weight, tigerLivingRegion, tigerBreed);
            default:
                throw new ArgumentException("Invalid animal!");
        }
    }
}
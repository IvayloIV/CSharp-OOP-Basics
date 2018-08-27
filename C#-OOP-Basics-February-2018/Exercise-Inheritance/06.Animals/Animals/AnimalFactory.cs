using System;

public static class AnimalFactory
{
    public static Animal GetAnimal(string animal, string name, int age, string gender)
    {
        switch (animal)
        {
            case "Cat":
                return new Cat(name, age, gender);
            case "Dog":
                return new Dog(name, age, gender);
            case "Frog":
                return new Frog(name, age, gender);
            case "Tomcat":
                return new Tomcat(name, age, gender);
            case "Kitten":
                return new Kitten(name, age, gender);
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}
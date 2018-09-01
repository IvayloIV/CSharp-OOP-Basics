using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Animal
{
    public Animal(string name, double weight)
    {
        this.name = name;
        this.weight = weight;
        this.foodEaten = 0;
    }

    private string name;
    private double weight;
    private int foodEaten;

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public abstract string ProduceSound();

    protected abstract double IncreaseWeight { get; }

    protected abstract Type[] TotalFoodEat { get; }

    public void TryToEatFood(Food food)
    {
        if (!this.TotalFoodEat.Contains(food.GetType()))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        this.FoodEaten += food.Quantity;
        this.weight += food.Quantity * this.IncreaseWeight;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.name}, " + "{0}" + 
        $"{this.weight}, " + "{1}" + $"{this.foodEaten}]";
    }
}
using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private const double MIN_WEIGHT = 1;
    private const double MAX_WEIGHT = 50;

    private string type;
    private double weight;

    public string Type
    {
        get { return type; }
        private set
        {
            var typeLowerCase = value.ToLower();
            if(typeLowerCase != "meat" && typeLowerCase != "veggies" 
                && typeLowerCase != "cheese" && typeLowerCase != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double CalculateCalories()
    {
        return 2 * this.weight * this.GetModifyToppint();
    }

    private double GetModifyToppint()
    {
        switch (this.type.ToLower())
        {
            case "meat":
                return 1.2;
            case "veggies":
                return 0.8;
            case "cheese":
                return 1.1;
            case "sauce":
                return 0.9;
            default:
                throw new ArgumentException($"Cannot place {this.type} on top of your pizza.");
        }
    }
}

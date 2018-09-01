using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override double IncreaseWeight => 0.35;

    protected override Type[] TotalFoodEat => new Type[] { 
        typeof(Meat), typeof(Fruit), typeof(Seeds), typeof(Vegetable),
    };

    public override string ProduceSound()
    {
        return "Cluck";
    }
}
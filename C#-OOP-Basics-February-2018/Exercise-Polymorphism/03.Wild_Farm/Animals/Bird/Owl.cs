using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override double IncreaseWeight => 0.25;

    protected override Type[] TotalFoodEat => new Type[] { typeof(Meat) };

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}
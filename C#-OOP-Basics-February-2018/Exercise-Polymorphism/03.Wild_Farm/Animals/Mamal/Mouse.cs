
using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

    protected override double IncreaseWeight => 0.1;

    protected override Type[] TotalFoodEat => new Type[] { typeof(Fruit), typeof(Vegetable)};

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), string.Empty);
    }
}
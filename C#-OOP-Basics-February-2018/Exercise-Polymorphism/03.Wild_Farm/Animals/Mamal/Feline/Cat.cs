using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed) { }

    protected override double IncreaseWeight => 0.3;

    protected override Type[] TotalFoodEat => new Type[] { typeof(Vegetable), typeof(Meat) };

    public override string ProduceSound()
    {
        return "Meow";
    }
}
using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion) { }

    protected override double IncreaseWeight => 0.4;

    protected override Type[] TotalFoodEat => new Type[] { typeof(Meat) };

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), string.Empty);
    }
}
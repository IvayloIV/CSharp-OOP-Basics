using System;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed) { }

    protected override double IncreaseWeight => 1;

    protected override Type[] TotalFoodEat => new Type[] { typeof(Meat) };

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }
}
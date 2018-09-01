public abstract class Mammal : Animal
{
    public Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.livingRegion = livingRegion;
    }

    private string livingRegion;

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), "{0}", $"{this.livingRegion}, ");
    }
}
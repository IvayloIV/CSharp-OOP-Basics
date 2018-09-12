public abstract class Bender
{
    protected Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private int power;

    public int Power
    {
        get { return power; }
        protected set { power = value; }
    }

    public abstract double TotalPower { get; }

    public override string ToString()
    {
        var type = this.GetType().Name;
        return $"###{type.Substring(0, type.IndexOf("Bender"))} Bender: {this.Name}, Power: {this.Power}";
    }
}
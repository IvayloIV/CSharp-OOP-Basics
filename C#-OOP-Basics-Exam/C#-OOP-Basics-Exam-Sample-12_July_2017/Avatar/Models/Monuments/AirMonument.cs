public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.airAffinity = airAffinity;
    }

    private int airAffinity;

    public int AirAffinity
    {
        get { return airAffinity; }
        protected set { airAffinity = value; }
    }

    public override int Power => this.airAffinity;

    public override string ToString()
    {
        return base.ToString() + $", Air Affinity: {this.airAffinity}";
    }
}
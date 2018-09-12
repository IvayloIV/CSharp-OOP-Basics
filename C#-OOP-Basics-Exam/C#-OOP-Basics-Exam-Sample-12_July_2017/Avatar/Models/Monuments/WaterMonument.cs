public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.waterAffinity = waterAffinity;
    }

    private int waterAffinity;

    public int WaterAffinity
    {
        get { return waterAffinity; }
        protected set { waterAffinity = value; }
    }

    public override int Power => this.waterAffinity;

    public override string ToString()
    {
        return base.ToString() + $", Water Affinity: {this.waterAffinity}";
    }
}
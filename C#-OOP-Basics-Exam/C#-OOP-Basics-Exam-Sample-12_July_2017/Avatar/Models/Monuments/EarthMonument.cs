public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.earthAffinity = earthAffinity;
    }

    private int earthAffinity;

    public int EarthAffinity
    {
        get { return earthAffinity; }
        protected set { earthAffinity = value; }
    }

    public override int Power => this.earthAffinity;

    public override string ToString()
    {
        return base.ToString() + $", Earth Affinity: {this.earthAffinity}";
    }
}
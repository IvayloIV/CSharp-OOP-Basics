public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.fireAffinity = fireAffinity;
    }

    private int fireAffinity;

    public int FireAffinity
    {
        get { return fireAffinity; }
        protected set { fireAffinity = value; }
    }

    public override int Power => this.fireAffinity;

    public override string ToString()
    {
        return base.ToString() + $", Fire Affinity: {this.fireAffinity}";
    }
}

public abstract class Bird : Animal
{
    public Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        this.wingSize = wingSize;
    }

    private double wingSize;

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), $"{this.wingSize}, ", string.Empty);
    }
}
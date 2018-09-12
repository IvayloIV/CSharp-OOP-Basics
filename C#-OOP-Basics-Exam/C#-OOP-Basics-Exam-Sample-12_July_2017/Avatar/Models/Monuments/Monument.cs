public abstract class Monument
{
    protected Monument(string name)
    {
        this.name = name;
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public abstract int Power { get; }

    public override string ToString()
    {
        var type = this.GetType().Name;
        return $"###{type.Substring(0, type.IndexOf("Monument"))} Monument: {this.Name}";
    }
}
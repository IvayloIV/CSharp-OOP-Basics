public abstract class Feline : Mammal
{
    public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
    {
        this.breed = breed; 
    }

    private string breed;

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public override string ToString()
    {
        return string.Format(base.ToString(), this.breed + ", ");
    }
}
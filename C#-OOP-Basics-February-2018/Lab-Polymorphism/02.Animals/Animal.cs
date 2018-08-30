public abstract class Animal
{
    public Animal(string name, string favouriteFood)
    {
        this.name = name;
        this.favouriteFood = favouriteFood;
    }

    private string name;
    private string favouriteFood;

    protected string Name
    {
        get { return name; }
        set { name = value; }
    }

    protected string FavouriteFood
    {
        get { return favouriteFood; }
        set { favouriteFood = value; }
    }

    public virtual string ExplainSelf()
    {
        return $"I am {this.name} and my fovourite food is {this.favouriteFood}";
    }
}
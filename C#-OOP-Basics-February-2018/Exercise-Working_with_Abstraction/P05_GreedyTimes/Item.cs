public class Item
{
    private long price;
    private string name;

    public long Price
    {
        get { return price; }
        set { price = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Item(string name, long price)
    {
        this.price = price;
        this.name = name;
    }
}
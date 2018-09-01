public abstract class Food
{
    public Food(int quantity)
    {
        this.quantity = quantity;
    }

    private int quantity;

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}
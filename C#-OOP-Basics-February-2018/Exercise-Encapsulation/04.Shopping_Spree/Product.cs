using System;

public class Product
{
    private string name;
    private int cost;

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Trim() == String.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public int Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
        }
    }

    public Product(string name, int money)
    {
        this.Name = name;
        this.Cost = money;
    }
}
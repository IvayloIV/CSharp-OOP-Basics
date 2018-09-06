using System;
using System.Collections.Generic;
using System.Text;

public abstract class Product
{
    protected Product(double price, double weight)
    {
        this.Price = price;
        this.Weight = weight;
    }
        
    private double price;

    public double Price
    {
        get { return price; }
        protected set 
        {
            if (value < 0)
            {
                throw new InvalidOperationException("Price cannot be negative!");
            }
            price = value;
        }
    }

    private double weight;

    public double Weight
    {
        get { return weight; }
        protected set { weight = value; }
    }

}
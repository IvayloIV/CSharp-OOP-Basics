using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int money;
    private List<Product> bag;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Trim() == String.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public int Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public List<Product> Bag
    {
        get { return bag; }
        private set { bag = value; }
    }

    public Person(string name, int money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public string BuyNewProduct(Product newProduct)
    {
        if (this.money >= newProduct.Cost)
        {
            this.bag.Add(newProduct);
            this.money -= newProduct.Cost;
            return $"{this.name} bought {newProduct.Name}";
        }
        return $"{this.name} can't afford {newProduct.Name}";
    }

    public override string ToString()
    {
        if (this.bag.Count == 0)
        {
            return $"{this.name} - Nothing bought";
        }
        else
        {
            return $"{this.name} - {String.Join(", ", this.Bag.Select(a => a.Name))}";
        }
    }
}
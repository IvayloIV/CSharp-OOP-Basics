using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MIN_LENGTH = 1;
    private const int MAX_LENGTH = 15;
    private const int MAX_TOPPINGS = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public IReadOnlyCollection<Topping> Toppings
    {
        get { return toppings; }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    public void AddNewTopping(Topping newTopping)
    {
        if (this.NumberOfTopping() + 1 > MAX_TOPPINGS)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(newTopping);
    }

    public int NumberOfTopping()
    {
        return this.toppings.Count;
    }

    public double TotalCalories()
    {
        return this.dough.CalculateCalories() + this.toppings.Sum(a => a.CalculateCalories());
    }
}
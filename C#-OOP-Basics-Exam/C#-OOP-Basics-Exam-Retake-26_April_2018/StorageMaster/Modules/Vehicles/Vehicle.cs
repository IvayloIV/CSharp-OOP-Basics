using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Vehicle
{
    protected Vehicle(int capacity)
    {
        this.Capacity = capacity;
        this.trunk = new Stack<Product>();
    }
    
    private int capacity;

    public int Capacity
    {
        get { return capacity; }
        protected set { capacity = value; }
    }

    private Stack<Product> trunk;

    public IReadOnlyCollection<Product> Trunk
    {
        get { return trunk; }
    }

    public bool IsFull => this.trunk.Sum(a => a.Weight) >= this.Capacity;

    public bool IsEmpty => this.trunk.Count == 0;

    public void LoadProduct(Product product) 
    {
        if (this.IsFull)
        {
            throw new InvalidOperationException("Vehicle is full!");
        }
        this.trunk.Push(product);
    }

    public Product Unload()
    {
        if (this.IsEmpty)
        {
            throw new InvalidOperationException("No products left in vehicle!");
        }
        return this.trunk.Pop();
    }
}
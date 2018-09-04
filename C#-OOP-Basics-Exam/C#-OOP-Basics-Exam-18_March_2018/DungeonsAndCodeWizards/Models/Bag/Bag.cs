using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Bag
{
    protected Bag(int capacity = 100)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    private int capacity;

    public int Capacity
    {
        get { return capacity; }
        protected set { capacity = value; }
    }

    private List<Item> items;

    public IReadOnlyCollection<Item> Items
    {
        get { return items; }
    }

    public double Load => this.items.Sum(a => a.Weight);

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }
        this.items.Add(item);
    }

    public Item GetItem(string name) 
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }
        var item = this.Items.FirstOrDefault(a => a.GetType().Name == name);
        if (item == null)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }
        this.items.Remove(item);
        return item;
    }
}
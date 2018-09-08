using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    public Box()
    {
        this.Items = new List<T>();
    }

    private List<T> Items { get; set; }

    public void Add(T item) 
    {
        this.Items.Add(item);
    }

    public T Remove()
    {
        var element = this.Items.Last();
        this.Items.RemoveAt(this.Items.Count - 1);
        return element;
    }

    public int Count => this.Items.Count;
}
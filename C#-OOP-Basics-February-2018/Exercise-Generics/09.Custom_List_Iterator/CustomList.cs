using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    public CustomList()
    {
        this.items = new List<T>();
    }

    public CustomList(IEnumerable<T> items)
    {
        this.items = new List<T>(items);
    }

    private IList<T> items;
    
    public void Add(T element)
    {
        this.items.Add(element);
    }

    public T Remove(int index)
    {
        var element = this.items[index];
        this.items.RemoveAt(index);
        return element;
    }

    public bool Contains(T element)
    {
        return this.items.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var element = this.items[index1];
        this.items[index1] = this.items[index2];
        this.items[index2] = element;
    }

    public int CountGreaterThan(T element)
    {
        var counter = 0;

        foreach (var item in this.items)
        {
            if (element.CompareTo(item) < 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.items.Max();
    }

    public T Min()
    {
        return this.items.Min();
    }

    public void Sort()
    {
        this.items = Sorter<T>.Sort(this.items);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        for (int i = 0; i < this.items.Count; i++)
        {
            builder.AppendLine(this.items[i].ToString());
        }

        return builder.ToString().TrimEnd();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in this.items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
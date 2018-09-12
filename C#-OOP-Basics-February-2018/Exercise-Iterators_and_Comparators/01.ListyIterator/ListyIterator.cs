using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    public ListyIterator(IList<T> items)
    {
        this.elements = new List<T>(items);
        this.currentIndex = 0;
    }

    private IList<T> elements;

    private int currentIndex;

    public bool Move() 
    {
        if (!this.HasNext()) 
        {
            return false;
        }
        this.currentIndex++;
        return true;
    }

    public bool HasNext()
    {
        return this.currentIndex + 1 < this.elements.Count;
    }

    public void Print()
    {
        if (this.elements.Count == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        Console.WriteLine(this.elements[this.currentIndex]);
    }
}
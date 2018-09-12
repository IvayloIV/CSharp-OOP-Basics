using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    public Stack()
    {
        this.elements = new List<T>();
    }

    private IList<T> elements;

    public void Push(params T[] items)
    {
        foreach (var item in items)
        {
            this.elements.Add(item);
        }
    }

    public void Pop()
    {
        if (this.elements.Count == 0) 
        {
            throw new ArgumentException("No elements");
        }
        this.elements.RemoveAt(this.elements.Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.elements.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
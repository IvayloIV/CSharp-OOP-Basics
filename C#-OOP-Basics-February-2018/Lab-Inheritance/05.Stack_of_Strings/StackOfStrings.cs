using System;
using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        if (this.data.Count > 0)
        {
            this.data.RemoveAt(this.data.Count - 1);
        }
        return this.Peek();
    }

    public string Peek()
    {
        var item = "";
        if (this.data.Count > 0)
        {
            item = this.data[this.data.Count - 1];
        }
        return item;
    }
}
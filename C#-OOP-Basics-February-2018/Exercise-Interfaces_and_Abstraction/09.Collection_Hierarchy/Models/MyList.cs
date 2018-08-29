using System.Collections.Generic;

public class MyList : Stack<string>, IAdd, IRemove, IUsed
{
    private int used;
    public int Used
    {
        get { return this.Count; }
    }

    public int Add(string item)
    {
        this.Push(item);
        return 0;
    }

    public string Remove()
    {
        var index = this.Used;
        return this.Pop();
    }
}

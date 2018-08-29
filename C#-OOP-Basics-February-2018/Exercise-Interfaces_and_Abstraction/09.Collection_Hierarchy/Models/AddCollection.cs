using System.Collections.Generic;

public class AddCollection : Queue<string>, IAdd
{
    public virtual int Add(string item)
    {
        var position = this.Count;
        this.Enqueue(item);
        return position;
    }
}
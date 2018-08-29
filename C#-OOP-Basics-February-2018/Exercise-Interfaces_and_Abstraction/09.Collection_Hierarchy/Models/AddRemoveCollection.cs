public class AddRemoveCollection : AddCollection, IRemove
{
    public override int Add(string item)
    {
        this.Enqueue(item);
        return 0;
    }
    public virtual string Remove()
    {
        var item = this.Dequeue();
        return item;
    }
}
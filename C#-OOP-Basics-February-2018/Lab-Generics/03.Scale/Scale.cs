using System;

public class Scale<T>
    where T : IComparable<T>
{
    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }

    public T left;

    public T right;

    public T GetHeavier()
    {
        var bigger = this.left.CompareTo(this.right);

        if (bigger > 0) 
        {
            return this.left;
        }
        else if (bigger < 0) 
        {
            return this.right;
        }
        return default(T);
    }
}
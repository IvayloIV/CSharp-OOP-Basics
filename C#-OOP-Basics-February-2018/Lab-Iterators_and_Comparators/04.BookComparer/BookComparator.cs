using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        var diff = x.Title.CompareTo(y.Title);
        if (diff == 0) 
        {
            diff = y.Year.CompareTo(x.Year);
        }
        return diff;
    }
}

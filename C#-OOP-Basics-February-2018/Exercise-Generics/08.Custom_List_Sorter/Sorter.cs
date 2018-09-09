using System.Collections.Generic;
using System.Linq;

public class Sorter<T>
{
    public static IList<T> Sort(IList<T> items)
    {
        return items.OrderBy(a => a).ToList();
    }
}

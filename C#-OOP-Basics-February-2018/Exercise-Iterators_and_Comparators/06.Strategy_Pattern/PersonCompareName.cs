using System.Collections.Generic;

public class PersonCompareName : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var diff = x.Name.Length.CompareTo(y.Name.Length);
        if (diff == 0)
        {
            var firstPersonLetter = x.Name[0].ToString().ToLower();
            var secondPersonLetter = y.Name[0].ToString().ToLower();
            diff = firstPersonLetter.CompareTo(secondPersonLetter);
        }
        return diff;
    }
}
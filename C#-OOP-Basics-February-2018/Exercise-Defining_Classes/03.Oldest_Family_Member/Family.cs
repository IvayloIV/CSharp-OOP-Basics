using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Family
{
    List<Person> people;

    public void AddMember(Person member)
    {
        people.Add(member);
    }

    public Person GetOldestMember()
    {
        return people.OrderByDescending(a => a.Age).FirstOrDefault();
    }

    public Family()
    {
        people = new List<Person>();
    }
}

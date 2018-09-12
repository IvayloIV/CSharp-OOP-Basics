using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        protected set { age = value; }
    }

    private string town;

    public string Town
    {
        get { return town; }
        protected set { town = value; }
    }

    public int CompareTo(Person other)
    {
        var diff = this.Name.CompareTo(other.Name);
        if (diff == 0) 
        {
            diff = this.Age.CompareTo(other.Age);
        }
        if (diff == 0)
        {
            diff = this.Town.CompareTo(other.Town);
        }
        return diff;
    }
}
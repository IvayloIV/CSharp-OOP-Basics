using System;

public class Person : IComparable<Person>
{
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
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

    public override string ToString()
    {
        return $"{this.name} {this.age}";
    }

    public override bool Equals(object obj)
    {
        var person = obj as Person;
        return this.age.Equals(person.Age) && this.name.Equals(person.Name);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }

    public int CompareTo(Person other)
    {
        var diff = this.Name.CompareTo(other.name);
        if (diff == 0)
        {
            diff = this.Age.CompareTo(other.Age);
        }
        return diff;
    }
}
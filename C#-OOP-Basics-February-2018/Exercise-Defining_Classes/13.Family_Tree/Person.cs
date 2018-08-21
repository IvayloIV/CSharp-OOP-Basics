using System;
using System.Collections.Generic;

public class Person
{
    string name;
    string birthdate;
    List<Person> parents;
    List<Person> children;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Birthdate
    {
        get { return this.birthdate; }
        set { this.birthdate = value; }
    }

    public List<Person> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Person> Children
    {
        get { return this.children; }
        set { this.children = value; }
    }

    public Person()
    {
        Parents = new List<Person>();
        Children = new List<Person>();
    }

    public Person(string name, string birthdate) : this()
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public override string ToString()
    {
        var result = $"{this.Name} {this.Birthdate}\nParents:";
        foreach (var parent in this.Parents)
        {
            result += $"\n{parent.Name} {parent.Birthdate}";
        }
        result += $"\nChildren:";
        foreach (var child in this.Children)
        {
            result += $"\n{child.Name} {child.Birthdate}";
        }
        return result;
    }
}
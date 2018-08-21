using System;

public class Children
{
    string name;
    string birthday;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Birthday
    {
        get { return this.birthday; }
        set { this.birthday = value; }
    }

    public Children(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}
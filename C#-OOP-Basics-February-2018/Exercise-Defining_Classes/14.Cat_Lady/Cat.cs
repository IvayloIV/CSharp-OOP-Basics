using System;

public class Cat
{
    string type;
    string name;
    double size;

    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public Cat(string type, string name, double size)
    {
        this.Type = type;
        this.Name = name;
        this.Size = size;
    }

    public override string ToString()
    {
        var result = $"{this.Type} {this.Name} ";
        if (this.Type == "Cymric")
        {
            result += $"{this.Size:f2}";
        }
        else
        {
            result += $"{this.Size}";
        }
        return result;
    }
}

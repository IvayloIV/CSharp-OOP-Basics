using System;

public class Cargo
{
    int weight;
    string type;

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }
    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }

    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }
}
using System;

class Car
{
    string model;
    Engine engine;
    int weight;
    string color;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public int Weight
    {
        get { return this.weight; }
        set { this.weight = value; }
    }

    public string Color
    {
        get { return this.color; }
        set { this.color = value; }
    }

    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = -1;
        this.Color = "n/a";
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        var result = $"{this.Model}:\n" + $"{this.Engine.ToString()}\n";
        if (this.Weight != -1)
        {
            result += $"  Weight: {this.Weight}\n";
        }
        else
        {
            result += $"  Weight: n/a\n";
        }
        return result + $"  Color: {this.Color}";
    }
}

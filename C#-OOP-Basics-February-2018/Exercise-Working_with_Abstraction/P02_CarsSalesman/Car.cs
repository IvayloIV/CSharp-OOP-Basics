using System;
using System.Text;

class Car
{
    private const string offset = "  ";

    public string model;
    public Engine engine;
    public int weight;
    public string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = -1;
        this.color = "n/a";
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        this.weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        this.color = color;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {
        this.weight = weight;
        this.color = color;
    }

    public override string ToString()
    {
        return GetFormatedCar();
    }

    private string GetFormatedCar()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("{0}:\n", this.model);
        result.Append(this.engine.ToString());
        if (this.weight == -1)
        {
            result.AppendFormat("{0}Weight: n/a\n", offset);
        }
        else
        {
            result.AppendFormat("{0}Weight: {1}\n", offset, this.weight.ToString());
        }
        result.AppendFormat("{0}Color: {1}", offset, this.color);
        return result.ToString();
    }
}
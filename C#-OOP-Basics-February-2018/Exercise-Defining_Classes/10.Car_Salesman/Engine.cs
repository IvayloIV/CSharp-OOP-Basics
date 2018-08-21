using System;


class Engine
{
    string model;
    int power;
    int displacement;
    string efficiency;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public int Displacement
    {
        get { return this.displacement; }
        set { this.displacement = value; }
    }

    public string Efficiency
    {
        get { return this.efficiency; }
        set { this.efficiency = value; }
    }

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = -1;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {
        this.Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public override string ToString()
    {
        var result = $"  {this.Model}:\n" + $"    Power: {this.Power}\n";
        if (this.Displacement != -1)
        {
            result += $"    Displacement: {this.Displacement}\n";
        }
        else
        {
            result += $"    Displacement: n/a\n";
        }
        return result + $"    Efficiency: {this.Efficiency}";
    }
}
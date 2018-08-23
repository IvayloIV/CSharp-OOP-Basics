using System;
using System.Text;

public class Engine
{
    private const string offset = "  ";

    public string model;
    public int power;
    public int displacement;
    public string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = -1;
        this.efficiency = "n/a";
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {
        this.displacement = displacement;
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        this.efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
        this.displacement = displacement;
        this.efficiency = efficiency;
    }

    public override string ToString()
    {
        return GetResultForPrint();
    }

    private string GetResultForPrint()
    {
        StringBuilder result = new StringBuilder();
        result.AppendFormat("{0}{1}:\n", offset, this.model);
        result.AppendFormat("{0}{0}Power: {1}\n", offset, this.power);
        if (this.displacement == -1)
        {
            result.AppendFormat("{0}{0}Displacement: n/a\n", offset);
        }
        else
        {
            result.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.displacement.ToString());
        }
        result.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.efficiency);

        return result.ToString();
    }
}

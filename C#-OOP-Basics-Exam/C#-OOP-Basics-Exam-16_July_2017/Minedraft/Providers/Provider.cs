using System;
using System.Text;

public abstract class Provider : Identificator
{
    const double MAX_ENERGY_OUTPUT = 10_000;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value >= MAX_ENERGY_OUTPUT)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        var typeName = this.GetType().Name;
        builder.AppendLine($"{typeName.Substring(0, typeName.IndexOf("Provider"))} Provider - {this.Id}")
            .AppendLine($"Energy Output: {this.energyOutput}");
        return builder.ToString().TrimEnd();
    }
}

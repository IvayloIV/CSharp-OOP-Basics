using System;
using System.Text;

public abstract class Harvester : Identificator
{
    const double MAX_ENERGY_REQUIREMENT = 20_000;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > MAX_ENERGY_REQUIREMENT)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        var typeName = this.GetType().Name;
        builder.AppendLine($"{typeName.Substring(0, typeName.IndexOf("Harvester"))} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.oreOutput}")
            .AppendLine($"Energy Requirement: {this.EnergyRequirement}");
        return builder.ToString().TrimEnd();
    }
}
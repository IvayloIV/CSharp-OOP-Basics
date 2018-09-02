using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
    }

    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester newHarvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(newHarvester);
            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (ArgumentException err)
        {
            return err.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider newProvider = ProviderFactory.CreateProvider(arguments);
            this.providers.Add(newProvider);
            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (ArgumentException err)
        {
            return err.Message;
        }
    }

    public string Day()
    {
        double summedOreOutput = 0;
        var summedEnergyOutput = providers.Sum(a => a.EnergyOutput);
        this.totalEnergyStored += summedEnergyOutput;
        var neededEnergy = harvesters.Sum(a => a.EnergyRequirement);
        var harvestersOreOutput = harvesters.Sum(a => a.OreOutput);

        if (this.mode == "Full" && this.totalEnergyStored >= neededEnergy)
        {
            this.totalEnergyStored -= neededEnergy;
            summedOreOutput += harvestersOreOutput;
        } 
        else if (this.mode == "Half" && this.totalEnergyStored >= neededEnergy * 0.6)
        {
            this.totalEnergyStored -= neededEnergy * 0.6;
            summedOreOutput += harvestersOreOutput * 0.5;
        }
        this.totalMinedOre += summedOreOutput;

        var builder = new StringBuilder();
        builder.AppendLine($"A day has passed.")
            .AppendLine($"Energy Provided: {summedEnergyOutput}")
            .AppendLine($"Plumbus Ore Mined: {summedOreOutput}");
        return builder.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0]; 
        this.mode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var harvester = this.harvesters.FirstOrDefault(a => a.Id == id);
        if (harvester == null) 
        {
            var provider = this.providers.FirstOrDefault(a => a.Id == id);
            if (provider == null) 
            {
                return $"No element found with id - {id}";
            }
            else
            {
                return provider.ToString();
            }
        }
        else
        {
            return harvester.ToString();
        }
    }

    public string ShutDown()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalEnergyStored}")
            .AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return builder.ToString().TrimEnd();
    }
}
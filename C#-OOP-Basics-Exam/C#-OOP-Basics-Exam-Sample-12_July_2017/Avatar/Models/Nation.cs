using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    public Nation(string name)
    {
        this.Name = name;
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    private List<Bender> Benders { get; set; }

    private List<Monument> Monuments { get; set; }

    private double TotalPowerBenders => this.Benders.Sum(a => a.TotalPower);

    public double TotalPower => this.TotalPowerBenders + ((this.TotalPowerBenders / 100) * this.Monuments.Sum(a => a.Power));

    public string Name { get; private set; }

    public void AddBender(Bender newBender)
    {
        this.Benders.Add(newBender);
    }

    public void AddMonument(Monument newMonument)
    {
        this.Monuments.Add(newMonument);
    }

    public void Destroy()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{this.Name} Nation");
        if (this.Benders.Count == 0)
        {
            builder.AppendLine($"Benders: None");
        }
        else
        {
            builder.AppendLine($"Benders:");
            foreach (var bender in this.Benders)
            {
                builder.AppendLine(bender.ToString());
            }
        }

        if (this.Monuments.Count == 0)
        {
            builder.AppendLine($"Monuments: None");
        }
        else
        {
            builder.AppendLine($"Monuments:");
            foreach (var monument in this.Monuments)
            {
                builder.AppendLine(monument.ToString());
            }
        }

        return builder.ToString().TrimEnd();
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    public NationsBuilder()
    {
        this.nations = new List<Nation>
        {
            new Nation("Air"),
            new Nation("Water"),
            new Nation("Fire"),
            new Nation("Earth"),
        };
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
        this.wars = new List<string>();
    }

    private List<Nation> nations;
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    private List<string> wars;

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var bender = this.benderFactory.CreateBender(benderArgs);
        var nation = this.nations.FirstOrDefault(a => a.Name == type);
        nation.AddBender(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var monument = this.monumentFactory.CreateMonument(monumentArgs);
        var nation = this.nations.FirstOrDefault(a => a.Name == type);
        nation.AddMonument(monument);
    }

    public string GetStatus(string nationsType)
    {
        var nation = this.nations.FirstOrDefault(a => a.Name == nationsType);
        return nation.ToString();
    }

    public void IssueWar(string nationsType)
    {
        foreach (Nation nation in this.nations.OrderByDescending(a => a.TotalPower).Skip(1))
        {
            nation.Destroy();
        }
        this.wars.Add(nationsType);
    }

    public string GetWarsRecord()
    {
        var builder = new StringBuilder();
        var count = 1;
        foreach (var war in this.wars)
        {
            builder.AppendLine($"War {count++} issued by {war}");
        }
        return builder.ToString().TrimEnd();
    }
}
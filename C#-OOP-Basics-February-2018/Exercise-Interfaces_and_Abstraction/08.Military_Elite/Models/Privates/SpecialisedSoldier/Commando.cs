using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; private set; }

    public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = new List<Mission>();
    }

    public void AddMission(Mission newMission)
    {
        if (newMission.State != "inProgress" && newMission.State != "Finished")
        {
            return;
        }
        this.Missions.Add(newMission);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine("Missions:");
        foreach (var mission in this.Missions)
        {
            builder.AppendLine($"  {mission.ToString()}");
        }
        return builder.ToString().TrimEnd();
    }
}
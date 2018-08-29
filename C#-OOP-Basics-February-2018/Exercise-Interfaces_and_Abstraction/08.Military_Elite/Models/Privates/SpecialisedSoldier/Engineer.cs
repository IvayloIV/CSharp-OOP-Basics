using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; private set; }

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = new List<Repair>();
    }

    public void AddRepairs(Repair newRepair)
    {
        this.Repairs.Add(newRepair);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine($"Repairs:");
        foreach (var repair in this.Repairs)
        {
            builder.AppendLine("  " + repair.ToString());
        }
        return builder.ToString().TrimEnd();
    }
}
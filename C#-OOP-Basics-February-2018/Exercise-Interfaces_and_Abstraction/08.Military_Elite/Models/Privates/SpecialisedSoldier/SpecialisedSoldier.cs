using System;
using System.Text;

public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public string Corps { get; private set; }

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary)
    {
        this.ValidateCorps(corps);
        this.Corps = corps;
    }

    private void ValidateCorps(string corps)
    {
        if (corps != "Airforces" && corps != "Marines")
        {
            throw new ArgumentException();
        }
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.ToString())
            .AppendLine($"Corps: {this.Corps}");
        return builder.ToString().TrimEnd();
    }
}
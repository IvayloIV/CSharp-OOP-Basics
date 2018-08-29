using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public List<Private> Privates { get; private set; }

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary) 
        : base(id, firstName, lastName, salary)
    {
        this.Privates = new List<Private>();
    }

    public void AddPrivate(Private newPrivate)
    {
        this.Privates.Add(newPrivate);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine("Privates:");
        foreach (var currentPrivate in this.Privates)
        {
            builder.AppendLine("  " + currentPrivate.ToString());
        }
        return builder.ToString().TrimEnd();
    }
}
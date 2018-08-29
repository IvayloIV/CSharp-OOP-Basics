using System.Text;

public class Spy : Soldier, ISpy
{
    public int CodeNumber { get; private set; }

    public Spy(int id, string firstName, string lastName, int codeNumber) 
        : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine($"Code Number: {this.CodeNumber}");
        return builder.ToString().TrimEnd();
    }
}
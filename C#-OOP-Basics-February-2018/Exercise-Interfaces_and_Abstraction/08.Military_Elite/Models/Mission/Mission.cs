public class Mission : IMission
{
    public string CodeName { get; private set; }
    public string State { get; private set; }

    public Mission(string codeName, string state)
    {
        this.CodeName = codeName;
        this.State = state;
    }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
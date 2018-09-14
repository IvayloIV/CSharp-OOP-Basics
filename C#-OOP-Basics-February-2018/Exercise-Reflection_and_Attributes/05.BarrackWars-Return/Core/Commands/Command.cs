using _03BarracksFactory.Contracts;

public abstract class Command : IExecutable
{
    private string[] data;

    public Command(string[] data)
    {
        this.data = data;
    }


    protected string[] Data
    {
        get { return data; }
        private set { data = value; }
    }

    public abstract string Execute();
}

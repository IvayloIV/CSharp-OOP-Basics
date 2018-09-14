using _03BarracksFactory.Contracts;

public abstract class Command : IExecutable
{
    private string[] data;
    private IRepository repository;
    private IUnitFactory unitFactory;

    public Command(string[] data, IRepository repository, IUnitFactory unitFactory)
    {
        this.data = data;
        this.repository = repository;
        this.unitFactory = unitFactory;
    }


    protected string[] Data
    {
        get { return data; }
        private set { data = value; }
    }

    protected IRepository Repository
    {
        get { return repository; }
        private set { repository = value; }
    }

    protected IUnitFactory UnitFactory
    {
        get { return unitFactory; }
        private set { unitFactory = value; }
    }

    public abstract string Execute();
}

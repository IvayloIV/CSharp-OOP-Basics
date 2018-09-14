using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

public class RetireCommand : Command
{
    public RetireCommand(string[] data, IRepository repository) 
        : base(data)
    {
        this.repository = repository;
    }

    [Inject]
    private IRepository repository;

    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }

    public override string Execute()
    {
        string unit = this.Data[1];
        try
        {
            this.Repository.RemoveUnit(unit);
            return $"{unit} retired!";
        }
        catch (Exception e)
        {
            throw new ArgumentException("No such units in repository.");
        }
    }
}

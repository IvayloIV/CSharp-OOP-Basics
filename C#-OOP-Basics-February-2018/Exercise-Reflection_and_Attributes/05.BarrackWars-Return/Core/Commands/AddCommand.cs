using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

public class AddCommand : Command
{
    public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    [Inject]
    private IRepository repository;

    public IRepository Repository
    {
        get { return repository; }
        set { repository = value; }
    }

    [Inject]
    private IUnitFactory unitFactory;

    public IUnitFactory UnitFactory
    {
        get { return unitFactory; }
        set { unitFactory = value; }
    }


    public override string Execute()
    {
        string unitType = Data[1];
        IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
        this.Repository.AddUnit(unitToAdd);
        string output = unitType + " added!";
        return output;
    }
}

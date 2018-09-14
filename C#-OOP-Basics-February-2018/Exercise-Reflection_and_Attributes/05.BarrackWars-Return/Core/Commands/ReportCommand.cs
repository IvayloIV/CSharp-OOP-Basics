using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

public class ReportCommand : Command
{
    public ReportCommand(string[] data, IRepository repository) 
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
        string output = this.Repository.Statistics;
        return output;
    }
}

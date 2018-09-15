public class Job : IJob
{
    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        this.Name = name;
        this.HoursOfWorkRequired = hoursOfWorkRequired;
        this.Employee = employee;
    }

    public int HoursOfWorkRequired { get; private set; }

    public string Name { get; private set; }

    public IEmployee Employee { get; private set; }

    public event JobDone JobEvent;

    public void Update()
    {
        this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;
        if (this.HoursOfWorkRequired <= 0)
        {
            this.JobEvent.Invoke(this);
        }
    }

    public override string ToString()
    {
        return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
    }
}
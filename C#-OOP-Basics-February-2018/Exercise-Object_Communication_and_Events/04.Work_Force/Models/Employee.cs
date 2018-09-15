public class Employee : IEmployee
{
    public Employee(string name, int workHoursPerWeek)
    {
        this.Name = name;
        this.WorkHoursPerWeek = workHoursPerWeek;
    }

    public int WorkHoursPerWeek { get; private set; }

    public string Name { get; private set; }
}
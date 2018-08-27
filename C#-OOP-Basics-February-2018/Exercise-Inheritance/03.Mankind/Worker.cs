using System;
using System.Text;

public class Worker : Human
{
    private const int MIN_SALARY = 10;
    private const int MIN_WORK_HOURS = 1;
    private const int MAX_WORK_HOURS = 12;

    private decimal weekSalary;
    private decimal workHoursPerDay;

    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        private set
        {
            if (value < MIN_WORK_HOURS || value > MAX_WORK_HOURS)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }


    public decimal WeekSalary
    {
        get { return weekSalary; }
        private set
        {
            if (value < MIN_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal GetSalaryPerHour()
    {
        return this.weekSalary / (this.workHoursPerDay * 5);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine(base.ToString());
        result.AppendLine($"Week Salary: {this.weekSalary:F2}");
        result.AppendLine($"Hours per day: {this.workHoursPerDay:F2}");
        result.AppendLine($"Salary per hour: {this.GetSalaryPerHour():F2}");
        return result.ToString().TrimEnd();
    }
}
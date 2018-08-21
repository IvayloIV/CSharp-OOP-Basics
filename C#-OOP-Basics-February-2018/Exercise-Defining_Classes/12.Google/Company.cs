using System;

public class Company
{
    string name;
    string department;
    double salary;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public double Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public Company()
    {
        this.Salary = -1;
    }

    public Company(string name, string department, double salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public override string ToString()
    {
        if (this.Salary == -1)
        {
            return $"Company:";
        }
        return $"Company:\n{this.Name} {this.Department} {this.salary:F2}";
    }
}
using System;

public class Employee
{
    string name;
    double salary;
    string position;
    string department;
    string email;
    int age;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public string Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Employee(string name, double salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, double salary, string position, string department, string email) :
        this(name, salary, position, department)
    {
        this.Email = email;
    }

    public Employee(string name, double salary, string position, string department, int age) :
       this(name, salary, position, department)
    {
        this.Age = age;
    }

    public Employee(string name, double salary, string position, string department, string email, int age) : 
        this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:F2} {this.Email} {this.Age}";
    }
}
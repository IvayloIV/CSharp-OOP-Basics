using System;
using System.Text;


public abstract class Animal
{
    private string name;
    private int age;
    private string gender;

    public string Name
    {
        get { return name; }
        protected set
        {
            CheckForEmpty(value);
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    public virtual string Gender
    {
        get { return gender; }
        protected set
        {
            CheckForEmpty(value);
            gender = value;
        }
    }

    private static void CheckForEmpty(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public virtual string ProduceSound()
    {
        return String.Empty;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine(this.GetType().Name);
        result.AppendLine($"{this.name} {this.age} {this.gender}");
        result.AppendLine(this.ProduceSound());
        return result.ToString().TrimEnd();
    }
}
using System;
using System.Text;

public class Human
{
    private const int MIN_LENGTH_FIRST_NAME = 4;
    private const int MIN_LENGTH_LAST_NAME = 3;

    private string firstName;
    private string lastName;

    public string LastName
    {
        get { return lastName; }
        protected set
        {
            ValidateFirstLetter(value, "lastName");
            ValidateLength(value, MIN_LENGTH_LAST_NAME, "lastName");
            lastName = value;
        }
    }

    public string FirstName
    {
        get { return firstName; }
        protected set
        {
            ValidateFirstLetter(value, "firstName");
            ValidateLength(value, MIN_LENGTH_FIRST_NAME, "firstName");
            firstName = value;
        }
    }

    private static void ValidateLength(string value, int length, string argument)
    {
        if (value.Length < length)
        {
            throw new ArgumentException($"Expected length at least {length} symbols! Argument: {argument}");
        }
    }

    private static void ValidateFirstLetter(string value, string argument)
    {
        if (!char.IsUpper(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {argument}");
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"First Name: {this.firstName}");
        result.AppendLine($"Last Name: {this.lastName}");
        return result.ToString().TrimEnd();
    }
}
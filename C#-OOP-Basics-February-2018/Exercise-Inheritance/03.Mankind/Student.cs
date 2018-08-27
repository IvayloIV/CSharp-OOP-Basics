using System;

public class Student : Human
{
    private const int MIN_LENGTH_FACULITY = 5;
    private const int MAX_LENGTH_FACULITY = 10;

    private string facultyNumber;

    public string FacultyNumber
    {
        private get { return facultyNumber; }
        set
        {
            if (value.Length < MIN_LENGTH_FACULITY || value.Length > MAX_LENGTH_FACULITY || !IsValidFaculityNumber(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    private bool IsValidFaculityNumber(string value)
    {
        foreach (var symbol in value)
        {
            if (!char.IsLetterOrDigit(symbol))
            {
                return false;
            }
        }
        return true;
    }

    public Student(string firstName, string lastName, string faculty) : base(firstName, lastName)
    {
        this.FacultyNumber = faculty;
    }

    public override string ToString()
    {
        var result = base.ToString();
        result += $"\nFaculty number: {this.facultyNumber}";
        return result;
    }
}
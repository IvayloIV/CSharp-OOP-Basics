using System;

public class Player
{
    private const int MIN_VALUE = 0;
    private const int MAX_VALUE = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Trim() == String.Empty)
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
    }

    public int Endurance
    {
        get { return endurance; }
        private set
        {
            ValidateSkill(value, "Endurance");
            endurance = value;
        }
    }

    public int Sprint
    {
        get { return sprint; }
        private set
        {
            ValidateSkill(value, "Sprint");
            sprint = value;
        }
    }

    public int Dribble
    {
        get { return dribble; }
        private set
        {
            ValidateSkill(value, "Dribble");
            dribble = value;
        }
    }

    public int Passing
    {
        get { return passing; }
        private set
        {
            ValidateSkill(value, "Passing");
            passing = value;
        }
    }

    public int Shooting
    {
        get { return shooting; }
        private set
        {
            ValidateSkill(value, "Shooting");
            shooting = value;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    private void ValidateSkill(int value, string skill)
    {
        if (value < MIN_VALUE || value > MAX_VALUE)
        {
            throw new ArgumentException($"{skill} should be between 0 and 100.");
        }
    }

    public double Skill()
    {
        return (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5d;
    }
}
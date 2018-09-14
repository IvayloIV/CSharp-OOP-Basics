using System;

public abstract class Gem : IGem
{
    public Gem(int strength, int agility, int vitality, string levelClarity)
    {
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;
        this.LevelClarity = (LevelClarity)Enum.Parse(typeof(LevelClarity), levelClarity);
    }

    public int Strength { get; private set; }

    public int Agility { get; private set; }

    public int Vitality { get; private set; }

    public LevelClarity LevelClarity { get; private set; }

    public int StrengthSum => this.Strength + (int)this.LevelClarity;

    public int AgilitySum => this.Agility + (int)this.LevelClarity;

    public int VitalitySum => this.Vitality + (int)this.LevelClarity;
}
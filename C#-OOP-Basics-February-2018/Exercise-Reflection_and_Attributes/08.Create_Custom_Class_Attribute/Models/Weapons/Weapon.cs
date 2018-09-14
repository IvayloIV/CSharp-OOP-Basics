using System;
using System.Collections.Generic;
using System.Linq;

[Project("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
public abstract class Weapon : IWeapon
{
    public Weapon(string name, string levelRarity, int socketsCapacity, int minDamage, int maxDamage)
    {
        this.name = name;
        this.levelRarity = (LevelRarity)Enum.Parse(typeof(LevelRarity), levelRarity);
        this.socketsCapacity = socketsCapacity;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.gems = Enumerable.Repeat(default(Gem), socketsCapacity).ToList();
    }

    private string name;

    public string Name
    {
        get { return name; }
    }

    private LevelRarity levelRarity;

    public LevelRarity LevelRarity
    {
        get { return levelRarity; }
        private set { levelRarity = value; }
    }

    private int socketsCapacity;

    public int SocketsCapacity
    {
        get { return socketsCapacity; }
        private set { socketsCapacity = value; }
    }

    private int minDamage;

    public int MinDamage
    {
        get { return minDamage; }
        private set { minDamage = value; }
    }

    private int maxDamage;

    public int MaxDamage
    {
        get { return maxDamage; }
        private set { maxDamage = value; }
    }

    private List<Gem> gems;

    public IReadOnlyCollection<Gem> Gems
    {
        get { return gems; }
    }

    public void AddNewGem(int socketIndex, Gem gem)
    {
        if (socketIndex >= 0 && socketIndex < this.socketsCapacity)
        {
            this.gems[socketIndex] = gem;
        }
    }

    public void RemoveGem(int socketIndex)
    {
        if (socketIndex >= 0 && socketIndex < this.socketsCapacity)
        {
            this.gems[socketIndex] = null;
        }
    }

    private int TotalMinDamage => this.minDamage * (int)this.LevelRarity;

    private int TotalMaxDamage => this.maxDamage * (int)this.LevelRarity;

    public override string ToString()
    {
        var validGems = this.gems.Where(a => a != null).ToList();
        var sumStrength = validGems.Sum(a => a.StrengthSum);
        var sumAgility = validGems.Sum(a => a.AgilitySum);
        var sumVitality = validGems.Sum(a => a.VitalitySum);

        var sumTotalMinDamage = this.TotalMinDamage + (sumStrength * 2) + sumAgility;
        var sumTotalMaxDamage = this.TotalMaxDamage + (sumStrength * 3) + (sumAgility * 4);

        return $"{this.Name}: {sumTotalMinDamage}-{sumTotalMaxDamage} Damage, " +
        $"+{sumStrength} Strength, +{sumAgility} Agility, +{sumVitality} Vitality";
    }
}

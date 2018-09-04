using System;

public abstract class Character
{
    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.Bag = bag;
        this.AbilityPoints = abilityPoints;
        this.Faction = faction;
        this.IsAlive = true;
        this.RestHealMultiplier = 0.2;
    }

    public void ReduceHealth(int power)
    {
        this.Health -= power;
        if (this.Health <= 0)
        {
            this.IsAlive = false; 
        }
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }
            name = value;
        }
    }

    private double baseHealth;

    public double BaseHealth
    {
        get { return baseHealth; }
        protected set { baseHealth = value; }
    }

    private double health;

    public double Health
    {
        get { return health; }
        protected set
        {
            if (value > this.BaseHealth)
            {
                value = this.BaseHealth;
            }
            if (value < 0) 
            {
                value = 0;
            }
            health = value;
        }
    }

    private double baseArmor;

    public double BaseArmor
    {
        get { return baseArmor; }
        protected set { baseArmor = value; }
    }

    private double armor;

    public double Armor
    {
        get { return armor; }
        protected set 
        {
            if (value > this.BaseArmor)
            {
                value = this.BaseArmor;
            }
            if (value < 0)
            {
                value = 0;
            }
            armor = value; 
        }
    }

    private double abilityPoints;

    public double AbilityPoints
    {
        get { return abilityPoints; }
        protected set { abilityPoints = value; }
    }

    private Bag bag;

    public Bag Bag
    {
        get { return bag; }
        protected set { bag = value; }
    }

    private Faction faction;

    public Faction Faction
    {
        get { return faction; }
        protected set { faction = value; }
    }

    private bool isAlive;

    public bool IsAlive
    {
        get { return isAlive; }
        protected set { isAlive = value; }
    }

    private double restHealMultiplier;

    public virtual double RestHealMultiplier
    {
        get { return restHealMultiplier; }
        protected set { restHealMultiplier = value; }
    }

    public void TakeDamage(double hitPoints)
    {
        this.CheckIsAlive();

        if (hitPoints > this.Armor) 
        {
            var diff = hitPoints - this.Armor;
            this.Armor = 0;
            this.Health -= diff;
        }
        else
        {
            this.Armor -= hitPoints;
        }

        if (this.Health <= 0)
        {
            this.IsAlive = false; 
        }
    }
    
    public void Rest() 
    {
        this.CheckIsAlive();
        this.Health += (this.BaseHealth * this.RestHealMultiplier);
    }

    public void CheckIsAlive()
    {
        if (this.IsAlive == false)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }

    public void HealCharacter(double abilityPoints)
    {
        var diff = this.BaseHealth - (this.Health + abilityPoints);
        if (diff >= 0)
        {
            this.Health += abilityPoints;
        }
        else
        {
            this.Health = this.BaseHealth;
            this.Armor += Math.Abs(diff);
            if (this.Armor > this.BaseArmor)
            {
                this.Armor = this.BaseArmor;
            }
        }
    }

    public void UseItem(Item item)
    {
        this.CheckIsAlive();
        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        this.CheckIsAlive();
        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        this.CheckIsAlive();
        character.CheckIsAlive();
        character.Bag.AddItem(item);
    }

    public void ReceiveItem(Item item)
    {
        this.CheckIsAlive();
        this.Bag.AddItem(item);
    }

    public void ResetArmor()
    {
        this.Armor = this.BaseArmor;
    }
}
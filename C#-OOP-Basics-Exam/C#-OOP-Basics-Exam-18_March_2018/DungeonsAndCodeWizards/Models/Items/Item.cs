using System;

public abstract class Item
{
    protected Item(int weight)
    {
        this.Weight = weight;
    }

    private int weight;

    public int Weight
    {
        get { return weight; }
        protected set { weight = value; }
    }

    public virtual void AffectCharacter(Character character)
    {
        if (character.IsAlive == false) 
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }
    }
}
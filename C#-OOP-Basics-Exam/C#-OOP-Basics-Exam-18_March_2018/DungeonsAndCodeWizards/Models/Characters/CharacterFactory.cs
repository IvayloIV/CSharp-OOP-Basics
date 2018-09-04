using System;

public class CharacterFactory
{
    public Character CreateCharacter(string faction, string characterType, string name)
    {
        if (!Enum.TryParse(faction, out Faction currentFaction))
        {
            throw new ArgumentException($"Invalid faction \"{faction}\"!");
        }
        switch (characterType)
        {
            case "Warrior":
                return new Warrior(name, currentFaction);
            case "Cleric":
                return new Cleric(name, currentFaction);
            default:
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
        }
    }
}
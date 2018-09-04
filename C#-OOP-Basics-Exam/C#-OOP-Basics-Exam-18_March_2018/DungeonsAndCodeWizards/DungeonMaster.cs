using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    public DungeonMaster()
    {
        this.items = new Stack<Item>();
        this.characters = new List<Character>();
        this.characterFactory = new CharacterFactory();
        this.itemFactory = new ItemFactory();
        this.lastSurvivorRounds = 0;
    }

    private int lastSurvivorRounds;
    Stack<Item> items;
    List<Character> characters;
    CharacterFactory characterFactory;
    ItemFactory itemFactory;

    public string JoinParty(string[] args)
    {
        var faction = args[0];
        var characterType = args[1];
        var name = args[2];
        this.characters.Add(characterFactory.CreateCharacter(faction, characterType, name));
        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        var itemName = args[0];
        this.items.Push(itemFactory.CreateItem(itemName));
        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];
        var currentCharacter = this.GetCharacter(characterName);
        IsBagEmpty();
        var item = this.items.Pop();
        currentCharacter.ReceiveItem(item);
        return $"{characterName} picked up {item.GetType().Name}!";
    }

    private void IsBagEmpty()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException($"No items left in pool!");
        }
    }

    private Character GetCharacter(string characterName)
    {
        var currentCharacter = characters.FirstOrDefault(a => a.Name == characterName);
        if (currentCharacter == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }
        return currentCharacter;
    }

    public string UseItem(string[] args)
    {
        var characterName = args[0];
        var itemName = args[1];
        var currentCharacter = this.GetCharacter(characterName);
        var item = currentCharacter.Bag.GetItem(itemName);
        currentCharacter.UseItem(item);
        return $"{characterName} used {itemName}.";
    } //CHECK

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giverCharacter = this.GetCharacter(giverName);
        var receiverCharacter = this.GetCharacter(receiverName);
        var item = giverCharacter.Bag.GetItem(itemName);
        giverCharacter.UseItemOn(item, receiverCharacter);
        return $"{giverName} used {itemName} on {receiverName}.";
    } //CHECK

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giverCharacter = this.GetCharacter(giverName);
        var receiverCharacter = this.GetCharacter(receiverName);
        var item = giverCharacter.Bag.GetItem(itemName);
        giverCharacter.GiveCharacterItem(item, receiverCharacter);
        return $"{giverName} gave {receiverName} {itemName}.";
    } //OK

    public string GetStats()
    {
        var builder = new StringBuilder();
        var sortedCharacters = this.characters.OrderByDescending(a => a.IsAlive).ThenByDescending(a => a.Health);
        foreach (var character in sortedCharacters)
        {
            var status = character.IsAlive == true ? "Alive" : "Dead";
            builder.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, " +
            $"AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
        }
        return builder.ToString().TrimEnd();
    }

    public string Attack(string[] args)
    {
        var attackerName = args[0];
        var receiverName = args[1];

        var attackerCharacter = this.GetCharacter(attackerName);
        var receiverCharacter = this.GetCharacter(receiverName);

        if (!(attackerCharacter is IAttackable))
        {
            throw new ArgumentException($"{attackerName} cannot attack!");
        }
        var warriorCharacter = (Warrior)attackerCharacter;
        warriorCharacter.Attack(receiverCharacter);
        var result = $"{attackerName} attacks {receiverName} for {warriorCharacter.AbilityPoints} hit points! ";
        result += $"{receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and ";
        result += $"{receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!";
        if (receiverCharacter.Health <= 0)
        {
            result += $"\n{receiverCharacter.Name} is dead!"; 
        }
        return result;
    }

    public string Heal(string[] args)
    {
        var healerName = args[0];
        var healingReceiverName = args[1];

        var healerCharacter = this.GetCharacter(healerName);
        var healingReceiverCharacter = this.GetCharacter(healingReceiverName);
        if (!(healerCharacter is IHealable))
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }
        var clericCharacter = (Cleric)healerCharacter;
        clericCharacter.Heal(healingReceiverCharacter);
        return $"{clericCharacter.Name} heals {healingReceiverCharacter.Name} for {clericCharacter.AbilityPoints}! " +
        $"{healingReceiverCharacter.Name} has {healingReceiverCharacter.Health} health now!";
    } //OK

    public string EndTurn(string[] args)
    {
        var builder = new StringBuilder();
        var aliveCharacters = this.characters.Where(a => a.IsAlive == true);
        foreach (var character in aliveCharacters)
        {
            var currentHealth = character.Health;
            character.Rest();
            builder.AppendLine($"{character.Name} rests ({currentHealth} => {character.Health})");
        }
        if (aliveCharacters.Count() <= 1)
        {
            this.lastSurvivorRounds++;
        }
        return builder.ToString().TrimEnd();
    }

    public bool IsGameOver()
    {
        return this.lastSurvivorRounds > 1;
    }
}
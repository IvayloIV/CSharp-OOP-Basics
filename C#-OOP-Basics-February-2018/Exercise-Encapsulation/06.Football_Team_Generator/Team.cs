using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private List<Player> players;

    public IReadOnlyCollection<Player> Players
    {
        get { return players; }
    }

    private string name;

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

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public void AddPlayer(Player newPlayer)
    {
        this.players.Add(newPlayer);
    }

    public void RemovePlayer(string playerName)
    {
        var searchPlayer = this.players.FirstOrDefault(a => a.Name == playerName);
        if (searchPlayer == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
        }
        players.Remove(searchPlayer);
    }

    public int GetStats()
    {
        if (this.players.Count == 0)
        {
            return 0;
        }
        return (int)Math.Round(this.players.Sum(a => a.Skill()) / this.players.Count);
    }
}
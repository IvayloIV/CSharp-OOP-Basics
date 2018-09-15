using System;
using System.Collections.Generic;
using System.Linq;

public class King : IAttackable
{
    public King(string name, ICollection<IDefender> defenders)
    {
        this.Name = name;
        this.Defenders = defenders;
    }

    public ICollection<IDefender> Defenders { get; private set; }

    public string Name { get; private set; }

    public event Attack AttackEvent;

    public void Defence()
    {
        Console.WriteLine($"King {this.Name} is under attack!");
        this.AttackEvent.Invoke();
    }

    public void AddDefender(IDefender defender)
    {
        this.Defenders.Add(defender);
        this.AttackEvent += defender.RespondAttack;
        defender.DefenceEvent += this.OnDefenderDie;
    }

    public void PoisonDefender(string name)
    {
        var currentDefender = this.Defenders.FirstOrDefault(a => a.Name == name);
        currentDefender.TakeHit();
    }

    public void OnDefenderDie(object obj)
    {
        this.Defenders.Remove((IDefender)obj);
    }
}

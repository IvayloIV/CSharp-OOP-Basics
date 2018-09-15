using System;
using System.Collections.Generic;

public delegate void Attack();

public interface IAttackable : INameable
{
    event Attack AttackEvent;

    ICollection<IDefender> Defenders { get; }

    void Defence();

    void OnDefenderDie(object obj);

    void AddDefender(IDefender defender);

    void PoisonDefender(string name);
}

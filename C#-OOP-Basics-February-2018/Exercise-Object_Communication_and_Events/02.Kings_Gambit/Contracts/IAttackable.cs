using System;
using System.Collections.Generic;

public delegate void Attack();

public interface IAttackable : INameable
{
    event Attack AttackEvent;

    ICollection<IDefender> Defenders { get; }

    void Defence();

    void AddDefender(IDefender defender);

    void KillDefender(string name);
}

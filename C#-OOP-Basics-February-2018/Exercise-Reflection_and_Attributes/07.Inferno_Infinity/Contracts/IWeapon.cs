using System.Collections.Generic;

public interface IWeapon
{
    string Name { get; }

    LevelRarity LevelRarity { get; }

    int SocketsCapacity { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    IReadOnlyCollection<Gem> Gems { get; }
}
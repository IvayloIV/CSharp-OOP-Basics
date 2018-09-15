public delegate void Defence(object obj);

public interface IDefender : INameable
{
    event Defence DefenceEvent;

    int Health { get; }

    bool IsAlive { get; }

    void TakeHit();

    void RespondAttack();
}
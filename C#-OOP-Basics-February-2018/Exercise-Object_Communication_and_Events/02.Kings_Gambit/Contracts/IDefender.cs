public interface IDefender : INameable
{
    bool IsAlive { get; }

    void Death();

    void RespondAttack();
}
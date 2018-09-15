public abstract class Defender : IDefender
{
    public Defender(string name)
    {
        this.Name = name;
        this.IsAlive = true;
    }

    public bool IsAlive { get; private set; }

    public string Name { get; private set; }

    public void Death()
    {
        this.IsAlive = false;
    }

    public abstract void RespondAttack();
}
public abstract class Defender : IDefender
{
    public Defender(string name, int health)
    {
        this.Name = name;
        this.IsAlive = true;
        this.Health = health;
    }

    public bool IsAlive { get; private set; }

    public string Name { get; private set; }

    public int Health { get; private set; }

    public event Defence DefenceEvent;

    public void TakeHit()
    {
        this.Health--;
        if (this.Health <= 0)
        {
            this.IsAlive = false;
            this.DefenceEvent(this);
        }
    }

    public abstract void RespondAttack();
}
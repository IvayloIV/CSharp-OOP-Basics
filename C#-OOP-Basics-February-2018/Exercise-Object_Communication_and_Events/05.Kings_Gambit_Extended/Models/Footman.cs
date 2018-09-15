using System;

public class Footman : Defender
{
    public Footman(string name) : base(name, 2)
    {
    }

    public override void RespondAttack()
    {
        if (this.IsAlive)
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is panicking!");
        }
    }
}

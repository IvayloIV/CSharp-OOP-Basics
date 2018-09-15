using System;

public class RoyalGuard : Defender
{
    public RoyalGuard(string name) : base(name)
    {
    }

    public override void RespondAttack()
    {
        if (this.IsAlive)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
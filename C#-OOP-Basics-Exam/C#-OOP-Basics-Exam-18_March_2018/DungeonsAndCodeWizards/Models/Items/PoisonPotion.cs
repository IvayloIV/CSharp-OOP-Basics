public class PoisonPotion : Item
{
    public PoisonPotion() : base(5)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.ReduceHealth(20);
    }
}
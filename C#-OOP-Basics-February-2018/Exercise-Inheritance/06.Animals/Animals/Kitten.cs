public class Kitten : Cat
{
    public Kitten(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string Gender
    {
        get { return base.Gender; }
        protected set
        {
            var gender = "Female";
            base.Gender = gender;
        }
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
}
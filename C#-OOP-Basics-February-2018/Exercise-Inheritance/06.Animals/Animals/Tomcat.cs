public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string Gender
    {
        get { return base.Gender; }
        protected set
        {
            var gender = "Male";
            base.Gender = gender;
        }
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }
}
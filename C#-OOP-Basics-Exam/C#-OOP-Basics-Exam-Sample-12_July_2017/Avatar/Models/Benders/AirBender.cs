public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) : base(name, power)
    {
        this.aerialIntegrity = aerialIntegrity;
    }

    private double aerialIntegrity;

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        protected set { aerialIntegrity = value; }
    }

    public override double TotalPower => this.Power * this.aerialIntegrity;

    public override string ToString()
    {
        return base.ToString() + $", Aerial Integrity: {this.aerialIntegrity:f2}";
    }
}
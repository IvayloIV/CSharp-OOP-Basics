public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.groundSaturation = groundSaturation;
    }

    private double groundSaturation;

    public double GroundSaturation
    {
        get { return groundSaturation; }
        protected set { groundSaturation = value; }
    }

    public override double TotalPower => this.Power * this.groundSaturation;

    public override string ToString()
    {
        return base.ToString() + $", Ground Saturation: {this.groundSaturation:f2}";
    }
}
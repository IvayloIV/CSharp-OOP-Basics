public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.waterClarity = waterClarity;
    }

    private double waterClarity;

    public double WaterClarity 
    {
        get { return waterClarity; }
        protected set { waterClarity = value; }
    }

    public override double TotalPower => this.Power * this.waterClarity;

    public override string ToString()
    {
        return base.ToString() + $", Water Clarity: {this.waterClarity:f2}";
    }
}
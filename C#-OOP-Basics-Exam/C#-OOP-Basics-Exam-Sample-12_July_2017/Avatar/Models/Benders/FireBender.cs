public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.heatAggression = heatAggression;
    }

    private double heatAggression;

    public double HeatAggression
    {
        get { return heatAggression; }
        protected set { heatAggression = value; }
    }

    public override double TotalPower => this.Power * this.heatAggression;

    public override string ToString()
    {
        return base.ToString() + $", Heat Aggression: {this.heatAggression:f2}";
    }
}
using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip) : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    private double grip;

    public double Grip
    {
        get { return grip; }
        private set { grip = value; }
    }

    public override double Degradation
    {
        get { return base.Degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            base.Degradation = value;
        }
    }

    public override void MakeALap()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}
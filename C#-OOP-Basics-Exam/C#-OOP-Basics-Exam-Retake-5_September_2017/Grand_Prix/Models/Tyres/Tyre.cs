using System;

public abstract class Tyre
{
    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private double hardness;

    public double Hardness
    {
        get { return hardness; }
        protected set { hardness = value; }
    }

    private double degradation;

    public virtual double Degradation
    {
        get { return degradation; }
        protected set 
        { 
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            degradation = value; 
        }
    }

    public virtual void MakeALap()
    {
        this.Degradation -= this.hardness;
    }
}
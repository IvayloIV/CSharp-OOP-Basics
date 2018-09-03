using System;

public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.IsDrive = true;
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private double totalTime;

    public double TotalTime
    {
        get { return totalTime; }
        protected set { totalTime = value; }
    }

    private Car car;

    public Car Car
    {
        get { return car; }
        protected set { car = value; }
    }

    private double fuelConsumptionPerKm;

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }

    public bool IsDrive { get; set; }

    public string ProblemType { get; set; }

    public virtual double Speed
    {
        get
        {
            return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        }
    }

    public void IncreaseTotalTime(double time)
    {
        this.totalTime += time;
    }

    public void DecreaseTotalTime(double time)
    {
        this.totalTime -= time;
    }

    public override string ToString()
    {
        var status = this.IsDrive ? this.totalTime.ToString("f3") : this.ProblemType;
        return $"{this.Name} {status}";
    }

    public void Fail(string message)
    {
        this.IsDrive = false;
        this.ProblemType = message;
    }

    internal void Crash()
    {
        this.Fail("Crashed");
    }
}
using System;

public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
            if (value > this.tankCapacity)
            {
                value = 0;
            }
            this.fuelQuantity = value;
        }
    }

    public double FuelConsumptionPerKm
    {
        get
        {
            return this.fuelConsumptionPerKm;
        }
        protected set
        {
            this.fuelConsumptionPerKm = value;
        }
    }

    public double TankCapacity
    {
        get
        {
            return tankCapacity;
        }
        set
        {
            tankCapacity = value;
        }
    }

    public string Drive(double distance)
    {
        var consumeLiters = distance * this.fuelConsumptionPerKm;
        if (consumeLiters > this.fuelQuantity)
        {
            return $"{this.GetType().Name} needs refueling";
        }
        this.fuelQuantity -= consumeLiters;
        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual string DriveEmpty(double distance)
    {
        throw new ArgumentException("Cannot drive empty " + this.GetType().Name);
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (liters + this.fuelQuantity > this.tankCapacity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        this.fuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }
}
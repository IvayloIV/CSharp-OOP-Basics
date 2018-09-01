public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    private double fuelQuantity;
    private double fuelConsumptionPerKm;

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
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
            this.fuelConsumptionPerKm = value ;
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

    public virtual void Refuel(double liters)
    {
        this.fuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
    }
}
using System;

public class Truck : Vehicle
{
    private const double AirConditioners = 1.6;
    private const double MissingFuelPercent = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm + AirConditioners, tankCapacity)
    {
    }

    public override void Refuel(double liters)
    {
        var currentLiters = liters * MissingFuelPercent;
        if (currentLiters + this.FuelQuantity > this.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }
        base.Refuel(currentLiters);
    }
}
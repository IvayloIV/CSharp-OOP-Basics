public class Truck : Vehicle
{
    private const double AirConditioners = 1.6;
    private const double MissingFuelPercent = 0.95;

    public Truck(double fuelQuantity, double fuelConsumptionPerKm) 
        : base(fuelQuantity, fuelConsumptionPerKm + AirConditioners)
    {
    }

    public override void Refuel(double liters)
    {
        base.Refuel(liters * MissingFuelPercent);
    }
}
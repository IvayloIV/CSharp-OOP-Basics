public class Bus : Vehicle
{
    const double AirConditioner = 1.4;

    public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) 
        : base(fuelQuantity, fuelConsumptionPerKm + AirConditioner, tankCapacity)
    {
    }

    public override string DriveEmpty(double distance)
    {
        this.FuelConsumptionPerKm -= AirConditioner;
        var result = base.Drive(distance);
        this.FuelConsumptionPerKm += AirConditioner;
        return result;
    }
}
public class Car : Vehicle
{
    private const double AirConditioners = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionPerKm ) 
        : base(fuelQuantity, fuelConsumptionPerKm + AirConditioners)
    {
    }
}
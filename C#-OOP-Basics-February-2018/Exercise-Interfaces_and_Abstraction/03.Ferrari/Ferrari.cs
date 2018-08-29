using System;

public class Ferrari : ICar
{
    public string Model { get; private set; }

    public string DriverName { get; private set; }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public Ferrari(string driverName)
    {
        this.Model = "488-Spider";
        this.DriverName = driverName;
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.DriverName}";
    }
}
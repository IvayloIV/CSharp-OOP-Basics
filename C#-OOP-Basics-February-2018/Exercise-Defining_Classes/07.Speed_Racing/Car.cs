using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    string model;
    double fuelAmount;
    double fuelConsumption;
    int distanceTraveled;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelConsumption = value; }
    }

    public int DistanceTraveled
    {
        get { return this.distanceTraveled; }
        private set { this.distanceTraveled = value; }
    }

    public Car (string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.distanceTraveled = 0;
    }

    public void TravelDistance(int amountOfKm)
    {
        if (amountOfKm * this.FuelConsumption > this.FuelAmount)
        {
            Console.WriteLine($"Insufficient fuel for the drive");
        }
        else
        {
            this.FuelAmount -= amountOfKm * this.FuelConsumption;
            this.DistanceTraveled += amountOfKm;
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTraveled}";
    }
}

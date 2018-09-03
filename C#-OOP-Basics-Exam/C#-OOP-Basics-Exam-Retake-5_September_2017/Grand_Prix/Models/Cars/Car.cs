using System;

public class Car
{
    private const int MAX_TANK_CAPACITY = 160;
    private int hp;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return hp; }
        protected set { hp = value; }
    }

    private double fuelAmount;

    public double FuelAmount
    {
        get { return fuelAmount; }
        protected set
        {   
            if (value > MAX_TANK_CAPACITY)
            {
                value = MAX_TANK_CAPACITY;
            }
            else if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            fuelAmount = value; 
        }
    }

    private Tyre tyre;

    public Tyre Tyre
    {
        get { return tyre; }
        protected set { tyre = value; }
    }

    public void ReduceFuelAmount(double num)
    {
        this.FuelAmount -= num;
    }

    public void IncreaseFuelAmount(double num)
    {
        this.FuelAmount += num;
    }

    public void ChangeTyre(Tyre type)
    {
        this.Tyre = type;
    }
}
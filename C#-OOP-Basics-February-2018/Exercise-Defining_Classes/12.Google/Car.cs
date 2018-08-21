using System;

public class Car
{
    string model;
    int speed;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int Speed
    {
        get { return this.speed; }
        set { this.speed = value; }
    }

    public Car()
    {
        this.Speed = -1;
    }

    public Car(string model, int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public override string ToString()
    {
        if (this.Speed == -1)
        {
            return $"Car:";
        }
        return $"Car:\n{this.Model} {this.Speed}";
    }
}
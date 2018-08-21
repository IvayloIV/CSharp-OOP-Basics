using System;
using System.Collections.Generic;

public class Car
{
    string model;
    Engine engine;
    Cargo cargo;
    List<Tire> tires;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }

    public List<Tire> Tires
    {
        get { return this.tires; }
        set { this.tires = value; }
    }

    public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = new List<Tire>() { tire1, tire2, tire3, tire4 };
    }

    public override string ToString()
    {
        return this.Model;
    }
}
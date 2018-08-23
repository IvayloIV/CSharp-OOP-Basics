using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public List<Tire> Tires { get; set; }

    public Car(string[] tokens)
    {
        this.Model = tokens[0];
        this.Engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
        this.Cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
        this.Tires = new List<Tire>();
        AddNewTire(tokens[5], tokens[6]);
        AddNewTire(tokens[7], tokens[8]);
        AddNewTire(tokens[9], tokens[10]);
        AddNewTire(tokens[11], tokens[12]);
    }

    private void AddNewTire(string pressure, string age)
    {
        this.Tires.Add(new Tire(int.Parse(age), double.Parse(pressure)));
    }
}
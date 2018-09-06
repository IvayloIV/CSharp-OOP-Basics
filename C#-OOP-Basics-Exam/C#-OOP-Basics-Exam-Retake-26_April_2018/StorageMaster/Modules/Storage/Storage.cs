using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Storage
{
    protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
    {
        this.Name = name;
        this.Capacity = capacity;
        this.GarageSlots = garageSlots;
        this.garage = new List<Vehicle>(vehicles);
        this.FillGarage();
        this.products = new List<Product>();
    }

    private void FillGarage()
    {
        var currentCapacity = this.garage.Count(); 
        for (int i = currentCapacity; i < this.garageSlots; i++)
        {
            this.garage.Add(null);
        }
    }

    private string name;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    private int capacity;

    public int Capacity
    {
        get { return capacity; }
        protected set { capacity = value; }
    }

    private int garageSlots;

    public int GarageSlots
    {
        get { return garageSlots; }
        protected set { garageSlots = value; }
    }

    private List<Vehicle> garage;

    public IReadOnlyCollection<Vehicle> Garage
    {
        get { return garage; }
    }

    private List<Product> products;

    public IReadOnlyCollection<Product> Products
    {
        get { return products; }
    }

    public bool IsFull => this.products.Sum(a => a.Weight) >= this.capacity;

    public Vehicle GetVehicle(int garageSlot)
    {
        ValidateGarageSlots(garageSlot);
        return this.garage[garageSlot];
    }

    private void ValidateGarageSlots(int garageSlot)
    {
        if (garageSlot >= this.garageSlots)
        {
            throw new InvalidOperationException("Invalid garage slot!");
        }
        if (this.garage[garageSlot] == null)
        {
            throw new InvalidOperationException("No vehicle in this garage slot!");

        }
    }

    public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
    {
        ValidateGarageSlots(garageSlot);
        deliveryLocation.IsHavindAFreeSlot();
        var vehicle = this.garage[garageSlot];
        this.garage[garageSlot] = null;
        return this.AddNewVehicle(deliveryLocation, vehicle);
    }

    public int AddNewVehicle(Storage deliveryLocation, Vehicle vehicle)
    {
        var freeIndex = deliveryLocation.garage.FindIndex(a => a == null);
        deliveryLocation.garage[freeIndex] = vehicle;
        return freeIndex;
    }

    public void IsHavindAFreeSlot()
    {
        if (this.garage.All(a => a != null))
        {
            throw new InvalidOperationException($"No room in garage!");
        }
    }

        public int UnloadVehicle(int garageSlot)
    {
        if (this.IsFull)
        {
            throw new InvalidOperationException("Storage is full!");
        }
        var vehicle = this.GetVehicle(garageSlot);
        var unloadedProducts = 0;
        while (!vehicle.IsEmpty && !this.IsFull)
        {
            var product = vehicle.Unload();
            this.products.Add(product);
            unloadedProducts++;
        }
        return unloadedProducts;
    }

    public string GetGaragesPrint()
    {
        var garages = new List<string>();
        foreach (var garage in this.garage)
        {
            garages.Add(garage == null ? "empty" : garage.GetType().Name);
        }
        return string.Join("|", garages);
    }

    public double GetSumProductWeight()
    {
        return this.products.Sum(a => a.Weight);
    }
}
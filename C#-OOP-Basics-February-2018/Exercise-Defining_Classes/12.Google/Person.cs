using System;
using System.Collections.Generic;

public class Person
{
    string name;
    Company company;
    Car car;
    List<Parent> parents;
    List<Children> childrens;
    List<Pokemon> pokemons;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Company Company
    {
        get { return this.company; }
        set { this.company = value; }
    }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public List<Parent> Parents
    {
        get { return this.parents; }
        set { this.parents = value; }
    }

    public List<Children> Childrens
    {
        get { return this.childrens; }
        set { this.childrens = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public Person(string name)
    {
        this.Name = name;
        this.Car = new Car();
        this.Company = new Company();
        this.Parents = new List<Parent>();
        this.Childrens = new List<Children>();
        this.Pokemons = new List<Pokemon>();
    }

    public override string ToString()
    {
        var result = this.Name + "\n" + this.Company.ToString() + "\n" + this.Car.ToString() + "\n";
        result += $"Pokemon:";
        foreach (var pokemon in this.Pokemons)
        {
            result += $"\n{pokemon.ToString()}";
        }
        result += $"\nParents:";
        foreach (var parent in this.Parents)
        {
            result += $"\n{parent.ToString()}";
        }
        result += $"\nChildren:";
        foreach (var children in this.Childrens)
        {
            result += $"\n{children.ToString()}";
        }
        return result;
    }
}
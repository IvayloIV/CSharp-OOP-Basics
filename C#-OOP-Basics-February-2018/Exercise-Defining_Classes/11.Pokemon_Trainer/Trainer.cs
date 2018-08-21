using System;
using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    string name;
    int badgets;
    List<Pokemon> pokemons;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Badgets
    {
        get { return this.badgets; }
        set { this.badgets = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        set { this.pokemons = value; }
    }

    public Trainer(string name, Pokemon pokemon)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>() { pokemon };
    }

    public void WinBadget(string elementName)
    {
        if (this.Pokemons.Any(a => a.Element == elementName && a.Health > 0))
        {
            this.Badgets++;
        }
        else
        {
            foreach (var pokemon in this.Pokemons)
            {
                pokemon.Health -= 10;
            }
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Badgets} {this.Pokemons.Where(a => a.Health > 0).Count()}";
    }
}
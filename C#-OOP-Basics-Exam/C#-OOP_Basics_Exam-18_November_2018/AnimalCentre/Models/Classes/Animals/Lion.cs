﻿namespace AnimalCentre.Models.Classes.Animals
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime) { }

        public override string ToString()
        {
            return $"    Animal type: {nameof(Lion)}" + base.ToString();
        }
    }
}
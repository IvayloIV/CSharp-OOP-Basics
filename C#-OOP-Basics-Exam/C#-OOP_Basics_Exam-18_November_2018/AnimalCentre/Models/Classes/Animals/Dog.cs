﻿namespace AnimalCentre.Models.Classes.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime) { }

        public override string ToString()
        {
            return $"    Animal type: {nameof(Dog)}" + base.ToString();
        }
    }
}
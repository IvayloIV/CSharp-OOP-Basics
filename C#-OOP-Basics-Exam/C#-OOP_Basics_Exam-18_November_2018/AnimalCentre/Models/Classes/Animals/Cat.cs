﻿namespace AnimalCentre.Models.Classes.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int procedureTime)
            : base(name, energy, happiness, procedureTime) { }

        public override string ToString()
        {
            return $"    Animal type: {nameof(Cat)}" + base.ToString();
        }
    }
}
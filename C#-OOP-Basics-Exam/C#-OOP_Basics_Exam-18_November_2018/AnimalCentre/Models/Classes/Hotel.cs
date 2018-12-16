using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AnimalCentre.Models.Classes
{
    public class Hotel : IHotel
    {
        public Hotel()
        {
            this.capacity = 10;
            this.animals = new Dictionary<string, IAnimal>();
        }

        private int capacity;

        public int Capacity
        { 
            get { return this.capacity; }
            private set { this.capacity = value; }
        }


        private Dictionary<string, IAnimal> animals;

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get { return this.animals; }
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count + 1 > this.capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            var currentAnimal = this.GetAnimalByName(animalName);
            currentAnimal.ChangeOwner(owner);
            currentAnimal.SetAdopt();

            this.animals.Remove(animalName);
        }

        public IAnimal GetAnimalByName(string name)
        {
            if (!this.animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            return this.animals[name];
        }
    }
}
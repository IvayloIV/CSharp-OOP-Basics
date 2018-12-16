using AnimalCentre.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace AnimalCentre.Models.Classes.Animals
{
    public class AnimalsFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var current = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(a => a.Name == type);

            if (current == null || !typeof(IAnimal).IsAssignableFrom(current))
            {
                throw new InvalidOperationException();
            }

            return (IAnimal)Activator.CreateInstance(current, new object[] { name, energy, happiness, procedureTime });
        }
    }
}
using System;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Classes.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);

            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }

            animal.ReduceHappiness(5);
            animal.SetChipped();
            this.AddAnimal(animal);
        }
    }
}
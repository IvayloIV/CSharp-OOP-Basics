using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Classes.Procedures
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.RemoveEnergy(6);
            animal.AddHappiness(12);

            this.AddAnimal(animal);
        }
    }
}

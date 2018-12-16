using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Classes.Procedures
{
    public class DentalCare : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.AddHappiness(12);
            animal.AddEnergy(10);

            this.AddAnimal(animal);
        }
    }
}
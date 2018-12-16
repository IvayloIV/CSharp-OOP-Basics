using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Classes.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.RemoveEnergy(8);
            animal.SetVaccinate();

            this.AddAnimal(animal);
        }
    }
}
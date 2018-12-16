using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Classes.Procedures
{
    public class Fitness : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.ReduceHappiness(3);
            animal.AddEnergy(10);

            this.AddAnimal(animal);
        }
    }
}
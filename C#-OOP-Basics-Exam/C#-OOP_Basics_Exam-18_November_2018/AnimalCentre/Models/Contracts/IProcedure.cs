using AnimalCentre.Models.Classes.Animals;
using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        IReadOnlyCollection<IAnimal> ProcedureHistory { get; }

        void DoService(IAnimal animal, int procedureTime);

        string History();

        void AddAnimal(IAnimal animal);
    }
}
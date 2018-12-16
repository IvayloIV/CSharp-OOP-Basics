namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        int Happiness { get; }

        int Energy { get; }

        int ProcedureTime { get; }

        string Owner { get; }

        bool IsAdopt { get; }

        bool IsChipped { get; }

        bool IsVaccinated { get; }

        void ReduceProcedureTime(int time);

        void ReduceHappiness(int happiness);

        void AddHappiness(int happiness);

        void SetChipped();

        void AddEnergy(int energy);

        void RemoveEnergy(int energy);

        void SetVaccinate();

        void SetAdopt();

        void ChangeOwner(string newOwner);
    }
}
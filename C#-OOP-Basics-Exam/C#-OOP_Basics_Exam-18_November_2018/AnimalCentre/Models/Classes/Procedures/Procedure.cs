using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Classes.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }

        private List<IAnimal> procedureHistory;

        public IReadOnlyCollection<IAnimal> ProcedureHistory
        {
            get { return this.procedureHistory; }
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ReduceProcedureTime(procedureTime);
        }

        public string History()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}");
            foreach (var animal in this.procedureHistory)
            {
                result.AppendLine(animal.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public void AddAnimal(IAnimal animal)
        {
            this.procedureHistory.Add(animal);
        }
    }
}
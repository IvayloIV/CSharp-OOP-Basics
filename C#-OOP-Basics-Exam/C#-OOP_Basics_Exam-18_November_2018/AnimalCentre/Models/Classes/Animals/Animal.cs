using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Classes.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        private string name;

        public string Name
        {
            get { return this.name; }    
            private set { this.name = value; }
        }

        private int happiness;

        public int Happiness
        {
            get 
            { 
                return this.happiness; 
            }

            private set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        private int energy;

        public int Energy
        {
            get
            {
                return this.energy;
            }

            private set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            }
        }

        private int procedureTime;

        public int ProcedureTime
        {
            get { return this.procedureTime; }
            private set { this.procedureTime = value; }
        }

        private string owner;

        public string Owner
        {
            get { return this.owner; }
            private set { this.owner = value; }
        }

        private bool isAdopt;

        public bool IsAdopt
        {
            get { return this.isAdopt; }
            private set { this.isAdopt = value; }
        }

        private bool isChipped;

        public bool IsChipped
        {
            get { return this.isChipped; }
            private set { this.isChipped = value; }
        }

        private bool isVaccinated;

        public bool IsVaccinated
        {
            get { return this.isVaccinated; }
            private set { this.isVaccinated = value; }
        }

        public void ReduceProcedureTime(int time)
        {
            this.ProcedureTime -= time;
        }

        public void ReduceHappiness(int happiness)
        {
            this.Happiness -= happiness;
        }

        public void AddHappiness(int happiness)
        {
            this.Happiness += happiness;
        }

        public void AddEnergy(int energy)
        {
            this.Energy += energy;
        }

        public void RemoveEnergy(int energy)
        {
            this.Energy -= energy;
        }

        public void SetChipped()
        {
            this.IsChipped = true;
        }

        public void SetVaccinate()
        {
            this.IsVaccinated = true;
        }

        public void SetAdopt()
        {
            this.IsAdopt = true;
        }

        public void ChangeOwner(string newOwner)
        {
            this.Owner = newOwner;
        }

        public override string ToString()
        {
            return $" - {this.name} - Happiness: {this.happiness} - Energy: {this.energy}";
        }
    }
}
using AnimalCentre.Models.Classes;
using AnimalCentre.Models.Classes.Animals;
using AnimalCentre.Models.Classes.Procedures;
using AnimalCentre.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre
{
    class AnimalCentre
    {
        private IHotel hotel;
        private AnimalsFactory animalsFactory;
        private ProceduresFactory proceduresFactory;
        private Dictionary<string, IProcedure> procedures;
        private Dictionary<string, List<IAnimal>> adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalsFactory = new AnimalsFactory();
            this.proceduresFactory = new ProceduresFactory();
            this.procedures = new Dictionary<string, IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = this.animalsFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            DoService(name, procedureTime, nameof(Chip));
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            DoService(name, procedureTime, nameof(Vaccinate));
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            DoService(name, procedureTime, nameof(Fitness));
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            DoService(name, procedureTime, nameof(Play));
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            DoService(name, procedureTime, nameof(DentalCare));
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            DoService(name, procedureTime, nameof(NailTrim));
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = this.hotel.GetAnimalByName(animalName);
            AddAdouptedAnimal(animal, owner);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            return this.procedures[type].History();
        }

        public string GetAdoptedAnimals()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var kvp in this.adoptedAnimals.OrderBy(a => a.Key))
            {
                builder.AppendLine($"--Owner: {kvp.Key}")
                       .AppendLine($"   - Adopted animals: {string.Join(" ", kvp.Value.Select(a => a.Name))}");
            }

            return builder.ToString().TrimEnd();
        }

        private void CheckExistensProcedure(string procedure)
        {
            if (!this.procedures.ContainsKey(procedure))
            {
                this.procedures[procedure] = this.proceduresFactory.CreateProcedure(procedure);
            }
        }

        private void DoService(string name, int procedureTime, string procedureName)
        {
            IAnimal animal = this.hotel.GetAnimalByName(name);
            CheckExistensProcedure(procedureName);

            this.procedures[procedureName].DoService(animal, procedureTime);
        }

        private void AddAdouptedAnimal(IAnimal animal, string owner)
        {
            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals[owner] = new List<IAnimal>();
            }

            this.adoptedAnimals[owner].Add(animal);
        }
    }
}
namespace AnimalCentre.Models.Classes.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)  { }

        public override string ToString()
        {
            return $"    Animal type: {nameof(Pig)}" + base.ToString();
        }
    }
}
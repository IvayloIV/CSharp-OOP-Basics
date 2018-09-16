using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AdoptionCenter : Center, IAdoptable
{
    public AdoptionCenter(string name) : base(name)
    {
    }

    public List<IAnimal> AdopAnimal()
    {
        var adopAnimals = this.ClearAnimals;
        foreach (var adopAnimal in adopAnimals)
        {
            this.Animals.Remove(adopAnimal);
        }
        return adopAnimals;
    }

    public List<IAnimal> SendForClearing()
    {
        var unClearingAnimals = this.Animals.Where(a => a.Status == Status.UNCLEAN).ToList();
        foreach (var unClearingAnimal in unClearingAnimals)
        {
            this.Animals.Remove(unClearingAnimal);
        }
        return unClearingAnimals;
    }

    public void AddNewAnimal(IAnimal animal)
    {
        this.Animals.Add(animal);
    }
}

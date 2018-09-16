using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CleansingCenter : Center, ICleanable
{
    public CleansingCenter(string name) : base(name)
    {
    }

    public void ReceiveAnimals(List<IAnimal> animals)
    {
        this.Animals.AddRange(animals);
    }

    public List<IAnimal> ClearAndSendAnimals()
    {
        foreach (var animal in this.Animals)
        {
            animal.ClearAnimal();
        }
        var currentAnimals = new List<IAnimal>(this.Animals);
        this.Animals.Clear();
        return currentAnimals;
    }
}
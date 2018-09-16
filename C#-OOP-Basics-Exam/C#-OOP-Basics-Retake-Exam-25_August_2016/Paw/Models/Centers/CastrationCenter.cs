using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CastrationCenter : Center, ICastratable
{
    public CastrationCenter(string name) : base(name)
    {
    }

    public List<IAnimal> CastrateAnimals()
    {
        var castrateAnimals = new List<IAnimal>(this.Animals);
        this.Animals.Clear();
        return castrateAnimals;
    }

    public void ReceiveAnimal(List<IAnimal> animals)
    {
        this.Animals.AddRange(animals);
    }
}

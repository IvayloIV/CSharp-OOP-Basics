using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Center : ICenter
{
    protected Center(string name)
    {
        this.Name = name;
        this.Animals = new List<IAnimal>();
    }

    public List<IAnimal> ClearAnimals => this.Animals.Where(a => a.Status == Status.CLEAN).ToList();

    public string Name { get; private set; }

    public List<IAnimal> Animals { get; protected set; }
}

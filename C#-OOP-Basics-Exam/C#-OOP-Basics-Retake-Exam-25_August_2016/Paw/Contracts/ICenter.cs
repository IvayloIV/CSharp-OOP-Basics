using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICenter
{
    string Name { get; }

    List<IAnimal> ClearAnimals { get; }

    List<IAnimal> Animals { get; }
}
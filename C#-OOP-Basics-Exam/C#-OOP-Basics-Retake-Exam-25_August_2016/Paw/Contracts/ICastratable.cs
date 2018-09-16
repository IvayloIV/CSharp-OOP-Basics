using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICastratable : ICenter
{
    void ReceiveAnimal(List<IAnimal> animals);

    List<IAnimal> CastrateAnimals();
}
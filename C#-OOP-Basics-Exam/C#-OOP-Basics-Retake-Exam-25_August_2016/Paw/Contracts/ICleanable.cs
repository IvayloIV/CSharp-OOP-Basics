using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICleanable : ICenter
{
    void ReceiveAnimals(List<IAnimal> animals);

    List<IAnimal> ClearAndSendAnimals();
}
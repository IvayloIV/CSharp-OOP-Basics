using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAdoptable : ICenter
{
    List<IAnimal> SendForClearing();

    List<IAnimal> AdopAnimal();

    void AddNewAnimal(IAnimal animal);
}
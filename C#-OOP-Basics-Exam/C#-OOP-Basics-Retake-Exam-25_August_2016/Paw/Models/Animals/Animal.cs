using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal : IAnimal
{
    protected Animal(string name, int age, string adoptCenterName)
    {
        this.Name = name;
        this.Age = age;
        this.Status = Status.UNCLEAN;
        this.AdoptCenterName = adoptCenterName;
    }

    public string AdoptCenterName { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public Status Status { get; private set; }

    public void ClearAnimal()
    {
        this.Status = Status.CLEAN;
    }
}
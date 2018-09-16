using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dog : Animal, IDog
{
    public Dog(string name, int age, int amountOfCommands, string adoptCenterName) : base(name, age, adoptCenterName)
    {
        this.AmountOfCommands = amountOfCommands;
    }

    public int AmountOfCommands { get; private set; }
}
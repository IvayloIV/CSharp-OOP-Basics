using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Animal, ICat
{
    public Cat(string name, int age, int intelligenceCoefficient, string adoptCenterName) : base(name, age, adoptCenterName)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient { get; private set; }
}
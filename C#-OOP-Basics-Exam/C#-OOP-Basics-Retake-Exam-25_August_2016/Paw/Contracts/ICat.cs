using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICat : IAnimal
{
    int IntelligenceCoefficient { get; }
}
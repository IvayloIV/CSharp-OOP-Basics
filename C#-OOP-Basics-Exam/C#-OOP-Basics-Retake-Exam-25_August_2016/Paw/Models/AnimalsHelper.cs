using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AnimalsHelper
{
    public AnimalsHelper()
    {
        this.AdoptedAnimals = new List<string>();
        this.CleansedAnimals = new List<string>();
        this.CastrateAnimals = new List<string>();
    }

    protected List<string> AdoptedAnimals { get; set; }

    protected List<string> CleansedAnimals { get; set; }

    protected List<string> CastrateAnimals { get; set; }

    protected string GetAdoptedAnimalsResult()
    {
        return this.GetResult(this.AdoptedAnimals);
    }

    protected string GetCleansedAnimalsResult()
    {
        return this.GetResult(this.CleansedAnimals);
    }

    protected string GetCastratAnimalsResult()
    {
        return this.GetResult(this.CastrateAnimals);
    }

    private string GetResult(List<string> animals)
    {
        return animals.Count == 0 ? "None" : string.Join(", ", animals.OrderBy(a => a).ToList());
    }
}
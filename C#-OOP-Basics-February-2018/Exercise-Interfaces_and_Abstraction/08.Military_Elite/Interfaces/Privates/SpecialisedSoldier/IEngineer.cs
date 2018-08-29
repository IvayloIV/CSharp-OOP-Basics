using System.Collections.Generic;

public interface IEngineer
{
    List<Repair> Repairs { get; }
    void AddRepairs(Repair newRepair);
}
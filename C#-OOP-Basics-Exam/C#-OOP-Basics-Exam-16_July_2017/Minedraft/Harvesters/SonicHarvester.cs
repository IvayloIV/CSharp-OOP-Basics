public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {
        this.sonicFactor = sonicFactor;
    }

    private int sonicFactor;

    public int SonicFactor
    {
        get { return sonicFactor; }
        protected set { sonicFactor = value; }
    }
}
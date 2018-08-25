using System;

public class Dough
{
    private const double MIN_WEIGHT = 1;
    private const double MAX_WEIGHT = 200;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public string FlourType
    {
        get { return flourType; }
        private set
        {
            var flourToLower = value.ToLower();
            if (flourToLower != "white" && flourToLower != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            var bakingTechToLower = value.ToLower();
            if (bakingTechToLower != "crispy" && bakingTechToLower != "chewy" && bakingTechToLower != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double CalculateCalories()
    {
        return (2 * this.weight) * this.GetMotifireDough(this.flourType) * this.GetMotifireDough(this.bakingTechnique);
    }

    private double GetMotifireDough(string value)
    {
        switch (value.ToLower())
        {
            case "crispy":
                return 0.9;
            case "chewy":
                return 1.1;
            case "homemade":
                return 1;
            case "white":
                return 1.5;
            case "wholegrain":
                return 1;
            default:
                throw new ArgumentException("Invalid type of dough.");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PawBuilder : AnimalsHelper
{
    public PawBuilder(ICollection<IAdoptable> adoptionCenters, 
        ICollection<ICleanable> cleansingCenters, 
        ICollection<ICastratable> castrateCenters)
    {
        this.adoptionCenters = adoptionCenters;
        this.cleansingCenters = cleansingCenters;
        this.castrateCenters = castrateCenters;
    }

    private ICollection<IAdoptable> adoptionCenters;
    private ICollection<ICleanable> cleansingCenters;
    private ICollection<ICastratable> castrateCenters;

    public void RegisterCleansingCenter(string[] tokens)
    {
        this.cleansingCenters.Add(new CleansingCenter(tokens[0]));
    }

    public void RegisterAdoptionCenter(string[] tokens)
    {
        this.adoptionCenters.Add(new AdoptionCenter(tokens[0]));
    }

    public void RegisterDog(string[] tokens)
    {
        var name = tokens[0];
        var age = int.Parse(tokens[1]);
        var learnedCommands = int.Parse(tokens[2]);
        var adoptionCenterName = tokens[3];

        var adoptCenter = this.GetAdoptCenter(adoptionCenterName);
        adoptCenter.AddNewAnimal(new Dog(name, age, learnedCommands, adoptionCenterName));
    }

    public void RegisterCat(string[] tokens)
    {
        var name = tokens[0];
        var age = int.Parse(tokens[1]);
        var intelligenceCoefficient = int.Parse(tokens[2]);
        var adoptionCenterName = tokens[3];

        var adoptCenter = this.GetAdoptCenter(adoptionCenterName);
        adoptCenter.AddNewAnimal(new Cat(name, age, intelligenceCoefficient, adoptionCenterName));
    }

    public void SendForCleansing(string[] tokens)
    {
        var adoptionCenterName = tokens[0];
        var cleansingCenterName = tokens[1];

        var clearCenter = this.GetCleanCenter(cleansingCenterName);
        var adoptCenter = this.GetAdoptCenter(adoptionCenterName);
        var animals = adoptCenter.SendForClearing();
        clearCenter.ReceiveAnimals(animals);
    }

    public void Cleanse(string[] tokens)
    {
        var cleansingCenterName = tokens[0];
        var clearCenter = this.GetCleanCenter(cleansingCenterName);
        var animals = clearCenter.ClearAndSendAnimals();
        foreach (var animal in animals)
        {
            var center = GetAdoptCenter(animal.AdoptCenterName);
            center.AddNewAnimal(animal);
            this.CleansedAnimals.Add(animal.Name);
        }
    }

    public void Adopt(string[] tokens)
    {
        var adoptionCenterName = tokens[0];
        var adoptCenter = GetAdoptCenter(adoptionCenterName);
        var adoptAnimals = adoptCenter.AdopAnimal();
        adoptAnimals.ForEach(a => this.AdoptedAnimals.Add(a.Name));
    }

    public void RegisterCastrationCenter(string[] tokens)
    {
        this.castrateCenters.Add(new CastrationCenter(tokens[0]));
    }

    public void SendForCastration(string[] tokens)
    {
        var adoptionCenterName = tokens[0];
        var castrationCenterName = tokens[1];

        var adoptCenter = this.GetAdoptCenter(adoptionCenterName);
        var castrateCenter = this.GetCastrateCenter(castrationCenterName);

        castrateCenter.ReceiveAnimal(adoptCenter.Animals);
        adoptCenter.Animals.Clear();
    }

    public void Castrate(string[] tokens)
    {
        var castrationCenterName = tokens[0];
        var castrateCenter = this.GetCastrateCenter(castrationCenterName);
        var animals = castrateCenter.CastrateAnimals();
        foreach (var animal in animals)
        {
            var center = GetAdoptCenter(animal.AdoptCenterName);
            center.AddNewAnimal(animal);
            this.CastrateAnimals.Add(animal.Name);
        }
    }

    public void CastrationStatistics(string[] tokens)
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Paw Inc. Regular Castration Statistics")
            .AppendLine($"Castration Centers: {this.castrateCenters.Count}")
            .AppendLine($"Castrated Animals: {this.GetCastratAnimalsResult()}");

        Console.WriteLine(builder.ToString().TrimEnd()); 
    }

    public string GetStatus()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Paw Incorporative Regular Statistics")
            .AppendLine($"Adoption Centers: {this.adoptionCenters.Count}")
            .AppendLine($"Cleansing Centers: {this.cleansingCenters.Count}")
            .AppendLine($"Adopted Animals: {this.GetAdoptedAnimalsResult()}")
            .AppendLine($"Cleansed Animals: {this.GetCleansedAnimalsResult()}")
            .AppendLine($"Animals Awaiting Adoption: {this.adoptionCenters.Sum(a => a.ClearAnimals.Count)}")
            .AppendLine($"Animals Awaiting Cleansing: {this.cleansingCenters.Sum(a => a.Animals.Count)}");

        return builder.ToString().TrimEnd();
    }

    private IAdoptable GetAdoptCenter(string adoptionCenterName)
    {
        return this.adoptionCenters.FirstOrDefault(a => a.Name == adoptionCenterName);
    }

    private ICleanable GetCleanCenter(string cleansingCenterName)
    {
        return this.cleansingCenters.FirstOrDefault(a => a.Name == cleansingCenterName);
    }

    private ICastratable GetCastrateCenter(string castrateCenterName)
    {
        return this.castrateCenters.FirstOrDefault(a => a.Name == castrateCenterName);
    }
}
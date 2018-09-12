using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicProcessor
{
    public ClinicProcessor()
    {
        this.pets = new List<Pet>();
        this.clinics = new List<Clinic>();
    }

    private List<Pet> pets;
    private List<Clinic> clinics;

    public void CreatePet(string[] tokens)
    {
        var name = tokens[1];
        var age = int.Parse(tokens[2]);
        var kind = tokens[3];
        this.pets.Add(new Pet(name, age, kind));
    }

    public void CreateClinic(string[] tokens)
    {
        var name = tokens[1];
        var rooms = int.Parse(tokens[2]);
        if (rooms % 2 == 0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        this.clinics.Add(new Clinic(name, rooms));
    }

    public bool AddPetToClinic(string[] tokens)
    {
        var petName = tokens[0];
        var currentPet = this.pets.FirstOrDefault(a => a.Name == petName);
        if (currentPet == null) 
        {
            throw new ArgumentException("Pet does not exist!");
        }
        var clinicName = tokens[1];
        var currentClinic = this.GetCurrentClinic(clinicName);

        var isAdded = currentClinic.AddPet(currentPet);
        if (isAdded)
        {
            this.pets.Remove(currentPet);
        }
        return isAdded;
    }

    public bool HasEmptyRooms(string[] tokens)
    {
        var clinicName = tokens[0];
        var currentClinic = this.GetCurrentClinic(clinicName);
        return currentClinic.HasEmptyRooms();
    }

    public bool Release(string[] tokens)
    {
        var clinicName = tokens[0];
        var currentClinic = this.GetCurrentClinic(clinicName);
        return currentClinic.Release();
    }

    public void Print(string[] tokens)
    {
        var clinicName = tokens[0];
        var currentClinic = this.GetCurrentClinic(clinicName);
        if (tokens.Length > 1)
        {
            var roomIndex = int.Parse(tokens[1]) - 1;
            if (roomIndex < 0 || roomIndex > currentClinic.Rooms.Count - 1)
            {
                throw new ArgumentException("Invalid room!");
            }
            Console.WriteLine(currentClinic.GetPetPrintByRoom(roomIndex));
        }
        else
        {
            Console.WriteLine(currentClinic.ToString());
        }
    }   

    private Clinic GetCurrentClinic(string clinicName)
    {
        var currentClinic = this.clinics.FirstOrDefault(a => a.Name == clinicName);
        if (currentClinic == null)
        {
            throw new ArgumentException("Clinic does not exist!");
        }
        return currentClinic;
    }
}
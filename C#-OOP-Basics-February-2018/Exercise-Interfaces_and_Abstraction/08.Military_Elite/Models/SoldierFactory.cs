using System;
using System.Collections.Generic;
using System.Linq;

public static class SoldierFactory
{
    public static Soldier FindSoldier(string[] tokens, List<Soldier> soldiers)
    {
        var id = int.Parse(tokens[1]);
        var firstName = tokens[2];
        var lastName = tokens[3];
        switch (tokens[0])
        {
            case "Private":
                return CreatePrivate(tokens, id, firstName, lastName);
            case "LeutenantGeneral":
                return CreateLeutenantGeneral(tokens, soldiers, id, firstName, lastName);
            case "Engineer":
                return CreateEngineer(tokens, id, firstName, lastName);
            case "Commando":
                return CreateCommando(tokens, id, firstName, lastName);
            case "Spy":
                return CreateSpy(tokens, id, firstName, lastName);
            default:
                throw new ArgumentException();
        }
    }

    private static Soldier CreateSpy(string[] tokens, int id, string firstName, string lastName)
    {
        var codeNumber = int.Parse(tokens[4]);
        var newSpy = new Spy(id, firstName, lastName, codeNumber);
        return newSpy;
    }

    private static Soldier CreateCommando(string[] tokens, int id, string firstName, string lastName)
    {
        var salary = decimal.Parse(tokens[4]);
        var corps = tokens[5];
        var commando = new Commando(id, firstName, lastName, salary, corps);
        AddMissions(tokens, commando);
        return commando;
    }

    private static Soldier CreateEngineer(string[] tokens, int id, string firstName, string lastName)
    {
        var salary = decimal.Parse(tokens[4]);
        var corps = tokens[5];
        var engineer = new Engineer(id, firstName, lastName, salary, corps);
        AddRepairs(tokens, engineer);
        return engineer;
    }

    private static Soldier CreateLeutenantGeneral(string[] tokens, List<Soldier> soldiers,
        int id, string firstName, string lastName)
    {
        var salary = decimal.Parse(tokens[4]);
        var leutenant = new LeutenantGeneral(id, firstName, lastName, salary);
        AddPrivates(tokens, soldiers, leutenant);
        return leutenant;
    }

    private static Soldier CreatePrivate(string[] tokens, int id, string firstName, string lastName)
    {
        var salary = decimal.Parse(tokens[4]);
        return new Private(id, firstName, lastName, salary);
    }

    private static void AddMissions(string[] tokens, Commando commando)
    {
        for (int i = 6; i < tokens.Length; i += 2)
        {
            var missionCodeName = tokens[i];
            var missionState = tokens[i + 1];
            var mission = new Mission(missionCodeName, missionState);
            commando.AddMission(mission);
        }
    }

    private static void AddRepairs(string[] tokens, Engineer engineer)
    {
        for (int i = 6; i < tokens.Length; i += 2)
        {
            var repairPart = tokens[i];
            var repairHours = int.Parse(tokens[i + 1]);
            var newRepair = new Repair(repairPart, repairHours);
            engineer.AddRepairs(newRepair);
        }
    }

    private static void AddPrivates(string[] tokens, List<Soldier> soldiers, LeutenantGeneral leutenant)
    {
        for (int i = 5; i < tokens.Length; i++)
        {
            var privateId = int.Parse(tokens[i]);
            var currentPrivate = soldiers.FirstOrDefault(a => a.Id == privateId);
            leutenant.AddPrivate((Private)currentPrivate);
        }
    }
}
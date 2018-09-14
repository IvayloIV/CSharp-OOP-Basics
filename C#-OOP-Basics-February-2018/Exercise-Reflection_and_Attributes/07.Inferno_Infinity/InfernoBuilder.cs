using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InfernoBuilder
{
    public InfernoBuilder()
    {
        this.weapons = new List<Weapon>();
        this.weaponFactory = new WeaponFactory();
        this.gemFactory = new GemFactory();
    }

    List<Weapon> weapons;
    WeaponFactory weaponFactory;
    GemFactory gemFactory;

    public void Create(string[] tokens)
    {
        var typeTokens = tokens[0].Split();
        var name = tokens[1];
        var levelRarity = typeTokens[0];
        var type = typeTokens[1];
        this.weapons.Add(weaponFactory.Create(type, name, levelRarity));
    }

    public void Add(string[] tokens)
    {
        var weaponName = tokens[0];
        var socketIndex = int.Parse(tokens[1]);
        var gemTokens = tokens[2].Split();
        var levelClarity = gemTokens[0];
        var typeGem = gemTokens[1];

        var gem = gemFactory.Create(typeGem, levelClarity);
        var weapon = this.GetWeapon(weaponName);

        weapon.AddNewGem(socketIndex, gem);
    }

    public void Remove(string[] tokens)
    {
        var weaponName = tokens[0];
        var socketIndex = int.Parse(tokens[1]);

        var weapon = this.GetWeapon(weaponName);
        weapon.RemoveGem(socketIndex);
    }

    public void Print(string[] tokens)
    {
        var weaponName = tokens[0];
        var weapon = this.GetWeapon(weaponName);
        Console.WriteLine(weapon.ToString());
    }

    private Weapon GetWeapon(string weaponName)
    {
        var weapon = this.weapons.FirstOrDefault(a => a.Name == weaponName);
        if (weapon == null)
        {
            throw new ArgumentException("Invalid weapon!");
        }
        return weapon;
    }
}
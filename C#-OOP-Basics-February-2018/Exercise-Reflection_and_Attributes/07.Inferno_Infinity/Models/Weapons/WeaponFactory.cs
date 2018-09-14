using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory
{
    public Weapon Create(string type, string name, string levelRarity)
    {
        var types = Assembly.GetCallingAssembly().GetTypes();
        var currentType = types.FirstOrDefault(a => a.Name == type);

        if (currentType == null || !typeof(Weapon).IsAssignableFrom(currentType))
        {
            throw new ArgumentException("Invalid weapon type!");
        }

        return (Weapon)Activator.CreateInstance(currentType, new object[] { name, levelRarity});
    }
}
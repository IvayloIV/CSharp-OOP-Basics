using System;
using System.Linq;
using System.Reflection;

public class GemFactory
{
    public Gem Create(string type, string levelClarity)
    {
        var types = Assembly.GetCallingAssembly().GetTypes();
        var currentType = types.FirstOrDefault(a => a.Name == type);

        if (currentType == null || !typeof(Gem).IsAssignableFrom(currentType))
        {
            throw new ArgumentException("Invalid gem type!");
        }

        return (Gem)Activator.CreateInstance(currentType, new object[] { levelClarity });
    }
}
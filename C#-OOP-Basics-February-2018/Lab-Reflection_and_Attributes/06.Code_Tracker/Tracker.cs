using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);
        var methods = classType
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods)
        {
            var attrs = method.GetCustomAttributes(typeof(SoftUniAttribute));
            foreach (SoftUniAttribute attr in attrs)
            {
                Console.WriteLine($"{method.Name} is written by {attr.Name}");
            }
        }
    }
}
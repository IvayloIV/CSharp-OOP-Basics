using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var builder = new StringBuilder();
        var classType = Type.GetType(className);
        var methods = classType
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods.Where(a => a.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(a => a.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return builder.ToString().TrimEnd();
    }
}
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className) 
    {
        var builder = new StringBuilder();
        var classType = Type.GetType(className);
        builder.AppendLine($"All Private Methods of Class: {className}");
        builder.AppendLine($"Base Class: {classType.BaseType.Name}");

        var methods = classType
        .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var method in methods)
        {
            builder.AppendLine(method.Name);
        }

        return builder.ToString().TrimEnd();
    }
}
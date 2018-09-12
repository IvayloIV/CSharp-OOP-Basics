using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className) 
    {
        var builder = new StringBuilder();
        var classType = Type.GetType(className);
        var filds = classType
        .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var fild in filds)
        {
            builder.AppendLine($"{fild.Name} must be private!");
        }

        var methods = classType
        .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


        foreach (var privateMethod in methods.Where(a => a.IsPrivate && a.Name.StartsWith("get")))
        {
            builder.AppendLine($"{privateMethod.Name} have to be public!");
        }

        foreach (var publicMethod in methods.Where(a => a.IsPublic && a.Name.StartsWith("set")))
        {
            builder.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return builder.ToString().TrimEnd();
    }
}

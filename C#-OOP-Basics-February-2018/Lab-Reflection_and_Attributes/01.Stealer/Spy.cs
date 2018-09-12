using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigateClassName, params string[] investigateFilds)
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Class under investigation: {investigateClassName}");

        var filds = Type.GetType(investigateClassName)
        .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        var instance = Activator.CreateInstance(Type.GetType(investigateClassName));
        foreach (var fild in filds)
        {
            if (investigateFilds.Contains(fild.Name))
            {
                builder.AppendLine($"{fild.Name} = {fild.GetValue(instance)}");
            }
        }

        return builder.ToString().TrimEnd();
    }
}

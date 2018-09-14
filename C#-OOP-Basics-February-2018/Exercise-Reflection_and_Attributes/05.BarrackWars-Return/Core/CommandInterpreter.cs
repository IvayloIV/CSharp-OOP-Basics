using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvidery)
    {
        this.serviceProvider = serviceProvidery;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        var type = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(a => a.Name.ToLower() == commandName + "command");

        if (type == null || !typeof(IExecutable).IsAssignableFrom(type))
        {
            throw new ArgumentException("Invalid command!");
        }

        var fieldsToInject = type
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(a => a.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

        var injectArgs = fieldsToInject.Select(a => this.serviceProvider.GetService(a.FieldType)).ToArray();

        var constrArg = new object[] { data }.Concat(injectArgs).ToArray();

        var instance = (IExecutable)Activator.CreateInstance(type, constrArg);

        return instance;
    }
}

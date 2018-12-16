using AnimalCentre.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace AnimalCentre.Models.Classes.Procedures
{
    public class ProceduresFactory
    {
        public IProcedure CreateProcedure(string type)
        {
            var current = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(a => a.Name == type);

            if (current == null || !typeof(IProcedure).IsAssignableFrom(current))
            {
                throw new InvalidOperationException();
            }

            return (IProcedure)Activator.CreateInstance(current);
        }
    }
}
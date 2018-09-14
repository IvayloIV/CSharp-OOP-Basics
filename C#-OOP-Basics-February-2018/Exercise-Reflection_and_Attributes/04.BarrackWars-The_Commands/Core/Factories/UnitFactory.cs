namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;
    using _03BarracksFactory.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(a => a.Name == unitType);

            if (type != null && typeof(Unit).IsAssignableFrom(type))
            {
                var instance = (IUnit)Activator.CreateInstance(type);
                return instance;
            }

            throw new ArgumentException("Invalid unit type!");
        }
    }
}
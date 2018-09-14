namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            var type = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(a => a.Name.ToLower() == commandName + "command");

            if (type == null || !typeof(IExecutable).IsAssignableFrom(type))
            {
                throw new ArgumentException("Invalid command!");
            }

            var instance = (IExecutable)Activator.CreateInstance(type, new object[] { data, this.repository, this.unitFactory });
            var method = type.GetMethod("Execute");

            try
            {
                var result = (string)method.Invoke(instance, new object[] { });
                return result;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}

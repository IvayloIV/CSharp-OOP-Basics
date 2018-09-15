using System;

namespace _01.Event_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                dispatcher.Name = name;
            }
        }
    }
}
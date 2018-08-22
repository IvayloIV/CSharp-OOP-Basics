using System;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            var command = "";
            while ((command = Console.ReadLine()) != "Exit")
            {
                studentSystem.ParseCommand(command);
            }
        }
    }
}
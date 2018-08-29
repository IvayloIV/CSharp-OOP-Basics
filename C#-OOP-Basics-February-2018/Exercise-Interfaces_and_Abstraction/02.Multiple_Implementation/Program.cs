using System;

namespace _02.Multiple_Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = (IBirthable)identifiable;
            Console.WriteLine(identifiable.Id);
            Console.WriteLine(birthable.Birthdate);

        }
    }
}
using System;
using System.Collections.Generic;

namespace _04.Person_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Pesho", 3, new List<BankAccount>());
            Console.WriteLine(person.GetBalance());
        }
    }
}

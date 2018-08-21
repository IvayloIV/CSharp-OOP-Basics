using System;

namespace _01.Define_a_Class_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPerson = new Person() { Name = "Pesho", Age = 20 };
            var secondPerson = new Person() { Name = "Gosho", Age = 18 };
            var thirdPerson = new Person() { Name = "Stamat", Age = 43 };
        }
    }
}
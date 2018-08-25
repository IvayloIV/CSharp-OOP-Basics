using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var products = new List<Product>();
                var people = new List<Person>();
                ReadInputPeople(people);
                ReadInputProducts(products);
                PurchaseProducts(products, people);
                PrintPeople(people);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static void PrintPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void PurchaseProducts(List<Product> products, List<Person> people)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var namePerson = tokens[0];
                var product = products.FirstOrDefault(a => a.Name == tokens[1]);
                var isBuySusses = people.FirstOrDefault(a => a.Name == namePerson).BuyNewProduct(product);
                Console.WriteLine(isBuySusses);
            }
        }

        private static void ReadInputProducts(List<Product> products)
        {
            var productsInput = Console.ReadLine().Split(new[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInput.Length; i += 2)
            {
                AddNewProduct(products, productsInput, i);
            }
        }

        private static void AddNewProduct(List<Product> products, string[] productsInput, int i)
        {
            var productName = productsInput[i];
            var productMoney = int.Parse(productsInput[i + 1]);
            products.Add(new Product(productName, productMoney));
        }

        private static void ReadInputPeople(List<Person> people)
        {
            var tokensPersonName = Console.ReadLine().Split(new[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokensPersonName.Length; i += 2)
            {
                AddMewPerson(people, tokensPersonName, i);
            }
        }

        private static void AddMewPerson(List<Person> people, string[] tokensPersonName, int i)
        {
            var personName = tokensPersonName[i];
            var personMoney = int.Parse(tokensPersonName[i + 1]);
            people.Add(new Person(personName, personMoney));
        }
    }
}

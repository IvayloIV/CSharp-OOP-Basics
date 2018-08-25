using System;

namespace _05.Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizza = CreatePizza();
                pizza.Dough = CreateDough();
                ReadAndAddTopping(pizza);
                var totalCalories = pizza.TotalCalories();
                Console.WriteLine($"{pizza.Name} - {totalCalories.ToString("F2")} Calories.");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private static void ReadAndAddTopping(Pizza pizza)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var toppingTokens = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var type = toppingTokens[1];
                var weight = double.Parse(toppingTokens[2]);
                var topping = new Topping(type, weight);
                pizza.AddNewTopping(topping);
            }
        }

        private static Dough CreateDough()
        {
            var doughTokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var flourType = doughTokens[1];
            var bakingTech = doughTokens[2];
            var weight = double.Parse(doughTokens[3]);
            var dough = new Dough(flourType, bakingTech, weight);
            return dough;
        }

        private static Pizza CreatePizza()
        {
            var inputPizza = Console.ReadLine().Split();
            var pizzaName = inputPizza[1];
            return new Pizza(pizzaName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Mordor_s_Cruel_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var foods = new List<Food>();
            AddFoodsInput(products, foods);
            var happinessPoints = foods.Sum(a => a.Happiness);
            var mood = MoodFactory.GetMood(happinessPoints);
            PrintResult(happinessPoints, mood);
        }

        private static void PrintResult(int happinessPoints, Mood mood)
        {
            Console.WriteLine(happinessPoints);
            Console.WriteLine(mood.Type);
        }

        private static void AddFoodsInput(string[] products, List<Food> foods)
        {
            for (int counter = 0; counter < products.Length; counter++)
            {
                var productName = products[counter];
                foods.Add(FoodFactory.GetFood(productName));
            }
        }
    }
}
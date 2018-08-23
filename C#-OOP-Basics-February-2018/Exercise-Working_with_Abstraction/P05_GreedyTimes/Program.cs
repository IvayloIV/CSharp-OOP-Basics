using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class Potato
    {
        public static long totalCapacity = 0;
        static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, List<Item>>
            {
                ["Gold"] = new List<Item>(),
                ["Gem"] = new List<Item>(),
                ["Cash"] = new List<Item>()
            };
            for (int i = 0; i < tokens.Length; i += 2)
            {
                string type = tokens[i];
                long itemAmount = long.Parse(tokens[i + 1]);

                if (capacity < totalCapacity + itemAmount)
                {
                    continue;
                }
                ValidateInput(bag, type, itemAmount);
            }
            PrintResult(bag);
        }

        private static void ValidateInput(Dictionary<string, List<Item>> bag, string type, long itemAmount)
        {
            var sumCash = GetSumOfCollection("Cash", bag);
            var sumGem = GetSumOfCollection("Gem", bag);
            var sumGold = GetSumOfCollection("Gold", bag);
            if (type.Length == 3 && IsValidRules(sumCash + itemAmount, sumGem, sumGold))
            {
                AddNewItem(bag, type, itemAmount, "Cash");
            }
            else if (type.ToLower().EndsWith("gem") && type.Length >= 4 &&
                IsValidRules(sumCash, sumGem + itemAmount, sumGold))
            {
                AddNewItem(bag, type, itemAmount, "Gem");
            }
            else if (type.ToLower() == "gold" &&
                IsValidRules(sumCash, sumGem, sumGold + itemAmount))
            {
                AddNewItem(bag, type, itemAmount, "Gold");
            }
        }

        private static long GetSumOfCollection(string name, Dictionary<string, List<Item>> bag)
        {
            return bag[name].Sum(a => a.Price);
        }

        private static void PrintResult(Dictionary<string, List<Item>> bag)
        {
            foreach (var pair in bag.OrderByDescending(a => a.Value.Sum(b => b.Price)))
            {
                if (pair.Value.Count() == 0)
                {
                    continue;
                }
                Console.WriteLine($"<{pair.Key}> ${pair.Value.Sum(b => b.Price)}");
                foreach (var item in pair.Value.OrderByDescending(item => item.Name).ThenBy(item => item.Price))
                {
                    Console.WriteLine($"##{item.Name} - {item.Price}");
                }
            }
        }

        private static void AddNewItem(Dictionary<string, List<Item>> bag, string type, long itemAmount, string name)
        {
            if (bag[name].All(a => a.Name != type))
            {
                bag[name].Add(new Item(type, itemAmount));
            }
            else
            {
                bag[name].FirstOrDefault(a => a.Name == type).Price += itemAmount;
            }
            totalCapacity += itemAmount;
        }

        private static bool IsValidRules(long cash, long gem, long gold)
        {
            return gold >= gem && gem >= cash;
        }
    }
}
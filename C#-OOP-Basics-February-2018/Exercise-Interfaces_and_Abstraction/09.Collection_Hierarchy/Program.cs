using System;
using System.Collections.Generic;

namespace _09.Collection_Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var collections = new List<IAdd>
            {
                new AddCollection(),
                new AddRemoveCollection(),
                new MyList()
            };
            var items = Console.ReadLine().Split();
            AddItemsToCollections(items, collections);
            var removeCount = int.Parse(Console.ReadLine());
            RemoveItems(removeCount, collections);
        }

        private static void RemoveItems(int removeCount, List<IAdd> collections)
        {
            for (int i = 1; i < collections.Count; i++)
            {
                var currentCollection = (IRemove)collections[i];
                var result = new List<string>();
                for (int j = 0; j < removeCount; j++)
                {
                    result.Add(currentCollection.Remove());
                }
                Console.WriteLine(String.Join(" ", result));
            }
        }

        private static void AddItemsToCollections(string[] items, List<IAdd> collections)
        {
            foreach (var collection in collections)
            {
                var result = new List<int>();
                foreach (var item in items)
                {
                    result.Add(collection.Add(item));
                }
                Console.WriteLine(String.Join(" ", result));
            }
        }
    }
}
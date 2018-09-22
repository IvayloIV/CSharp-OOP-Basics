using System;
using System.Linq;

namespace _09.Linked_List_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            var type = typeof(LinkedList<int>);
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var methodName = tokens[0];
                var value = int.Parse(tokens[1]);
                var method = type.GetMethod(methodName);
                method.Invoke(linkedList, new object[] { value });
            }

            PrintResult(linkedList);
        }

        private static void PrintResult(LinkedList<int> linkedList)
        {
            Console.WriteLine(linkedList.Count);
            foreach (var item in linkedList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
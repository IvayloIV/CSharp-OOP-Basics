using System;

namespace _05.Stack_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new StackOfStrings();
            data.Push("1");
            Console.WriteLine(data.Peek());
            data.Pop();
            Console.WriteLine(data.IsEmpty());
        }
    }
}
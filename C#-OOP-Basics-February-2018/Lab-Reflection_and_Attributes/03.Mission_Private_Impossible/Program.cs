using System;

namespace _03.Mission_Private_Impossible
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }
    }
}
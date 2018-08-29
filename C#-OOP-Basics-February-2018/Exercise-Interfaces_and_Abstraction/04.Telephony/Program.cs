using System;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var mobile = new Smartphone("Samsung");
            ReadPhones(mobile);
            ReadWorldWebs(mobile);
        }

        private static void ReadWorldWebs(Smartphone mobile)
        {
            var webs = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.None);
            foreach (var web in webs)
            {
                Console.WriteLine(mobile.Browsing(web));
            }
        }

        private static void ReadPhones(Smartphone mobile)
        {
            var phones = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.None);
            foreach (var phone in phones)
            {
                Console.WriteLine(mobile.Call(phone));
            }
        }
    }
}
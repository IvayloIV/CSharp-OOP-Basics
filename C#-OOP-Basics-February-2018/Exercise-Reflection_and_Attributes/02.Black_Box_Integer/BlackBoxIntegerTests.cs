namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = typeof(BlackBoxInteger);
            var blackBox = Activator.CreateInstance(classType, true);
            var innerValue = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var tokens = line.Split("_");
                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                InvokeMethod(command, blackBox, classType, value);
                Console.WriteLine(innerValue.GetValue(blackBox));
            }
        }

        private static void InvokeMethod(string command, object blackBox, Type classType, int value)
        {
            classType.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(blackBox, new object[] { value });
        }
    }
}

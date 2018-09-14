using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Traffic_Lights
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Light> trafficLights = Console.ReadLine().Split().Select(a => (Light)Enum.Parse(typeof(Light), a)).ToList();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < trafficLights.Count; k++)
                {
                    trafficLights[k] = (Light)(((int)trafficLights[k] + 1) % Enum.GetNames(typeof(Light)).Length);
                }
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
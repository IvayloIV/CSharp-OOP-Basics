using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Paw
{
    class Program
    {
        static void Main(string[] args)
        {
            var adoptionCenter = new List<IAdoptable>();
            var cleansingCenter = new List<ICleanable>();
            var castratingCenter = new List<ICastratable>();
            var pawBuilder = new PawBuilder(adoptionCenter, cleansingCenter, castratingCenter);

            var type = typeof(PawBuilder);
            string line;
            while ((line = Console.ReadLine()) != "Paw Paw Pawah")
            {
                var tokensInput = line.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokensInput[0];
                var tokens = tokensInput.Skip(1).ToArray();

                var method = type.GetMethod(command);
                method.Invoke(pawBuilder, new object[] { tokens });
            }

            Console.WriteLine(pawBuilder.GetStatus());
        }
    }
}
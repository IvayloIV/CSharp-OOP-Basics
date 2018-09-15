using P03_DependencyInversion;
using System;

namespace _03.Dependency_Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var additionStrategy = new AdditionStrategy();
            var calculator = new PrimitiveCalculator(additionStrategy);

            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                if (tokens[0] == "mode")
                {
                    var @operator = char.Parse(tokens[1]);
                    IStrategy strategy = CreateStrategy(additionStrategy, @operator);
                    calculator.ChangeStrategy(strategy);
                }
                else 
                {
                    var leftOperand = int.Parse(tokens[0]);
                    var rightOperand = int.Parse(tokens[1]);
                    var result = calculator.PerformCalculation(leftOperand, rightOperand);
                    Console.WriteLine(result);
                }
            }
        }

        private static IStrategy CreateStrategy(AdditionStrategy additionStrategy, char @operator)
        {
            IStrategy strategy = null;

            switch (@operator)
            {
                case '+':
                    strategy = additionStrategy;
                    break;
                case '-':
                    strategy = new SubtractionStrategy();
                    break;
                case '*':
                    strategy = new MultiplicationStrategy();
                    break;
                case '/':
                    strategy = new DivisionStrategy();
                    break;
            }

            return strategy;
        }
    }
}

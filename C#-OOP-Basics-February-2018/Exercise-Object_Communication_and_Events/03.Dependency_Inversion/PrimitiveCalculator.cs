namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(IStrategy newStrategy)
        {
            this.strategy = newStrategy;
        }

        public int PerformCalculation(int leftOperand, int rightOperand)
        {
            return strategy.Calculate(leftOperand, rightOperand);
        }
    }
}
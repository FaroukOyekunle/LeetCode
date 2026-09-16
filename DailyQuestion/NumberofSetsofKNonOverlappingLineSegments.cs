namespace DailyQuestion
{
    public class NumberofSetsofKNonOverlappingLineSegments
    {
        private const long Modulo = 1_000_000_007;
        private const int MaximumPointCount = 1000;

        private static readonly long[] FactorialValues = new long[2 * MaximumPointCount];
        private static readonly long[] ModularInverseValues = new long[2 * MaximumPointCount];
        private static readonly long[] InverseFactorialValues = new long[2 * MaximumPointCount];

        static Solution()
        {
            FactorialValues[0] = 1;
            FactorialValues[1] = 1;

            ModularInverseValues[1] = 1;

            InverseFactorialValues[0] = 1;
            InverseFactorialValues[1] = 1;

            for (int currentNumber = 2; currentNumber < FactorialValues.Length; currentNumber++)
            {
                FactorialValues[currentNumber] = FactorialValues[currentNumber - 1] * currentNumber % Modulo;

                ModularInverseValues[currentNumber] = ModularInverseValues[Modulo % currentNumber] * (Modulo - Modulo / currentNumber) % Modulo;

                InverseFactorialValues[currentNumber] = InverseFactorialValues[currentNumber - 1] * ModularInverseValues[currentNumber] % Modulo;
            }
        }

        public int NumberOfSets(int pointCount, int segmentCount)
        {
            int combinationTotal = pointCount + segmentCount - 1;
            int combinationSize = 2 * segmentCount;

            return (int)CalculateCombination(combinationTotal, combinationSize);
        }

        private long CalculateCombination(int totalItemCount, int selectedItemCount)
        {
            return FactorialValues[totalItemCount] * InverseFactorialValues[totalItemCount - selectedItemCount] % Modulo * InverseFactorialValues[selectedItemCount] %  Modulo;
        }
    }
}
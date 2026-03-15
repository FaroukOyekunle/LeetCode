namespace DailyQuestion
{
    public class FancySequence
    {
        private const long MODULO = 1_000_000_007;

        private List<long> normalizedSequenceValues;
        private long cumulativeMultiplier;
        private long cumulativeIncrement;

        public Fancy()
        {
            normalizedSequenceValues = new List<long>();

            cumulativeMultiplier = 1;
            cumulativeIncrement = 0;
        }

        public void Append(int valueToAppend)
        {
            long normalizedStoredValue = ((valueToAppend - cumulativeIncrement + MODULO) % MODULO) * ComputeModularInverse(cumulativeMultiplier) % MODULO;

            normalizedSequenceValues.Add(normalizedStoredValue);
        }

        public void AddAll(int incrementValue)
        {
            cumulativeIncrement = (cumulativeIncrement + incrementValue) % MODULO;
        }

        public void MultAll(int multiplicationFactor)
        {
            cumulativeMultiplier = (cumulativeMultiplier * multiplicationFactor) % MODULO;
            cumulativeIncrement = (cumulativeIncrement * multiplicationFactor) % MODULO;
        }

        public int GetIndex(int index)
        {
            if (index >= normalizedSequenceValues.Count)
            {
                return -1;
            }

            long transformedValue = (normalizedSequenceValues[index] * cumulativeMultiplier % MODULO + cumulativeIncrement) % MODULO;

            return (int)transformedValue;
        }

        private long ComputeModularInverse(long value)
        {
            return ModularExponentiation(value, MODULO - 2);
        }

        private long ModularExponentiation(long baseValue, long exponent)
        {
            long exponentiationResult = 1;

            baseValue %= MODULO;

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    exponentiationResult = exponentiationResult * baseValue % MODULO;
                }

                baseValue = baseValue * baseValue % MODULO;

                exponent >>= 1;
            }

            return exponentiationResult;
        }
    }
}
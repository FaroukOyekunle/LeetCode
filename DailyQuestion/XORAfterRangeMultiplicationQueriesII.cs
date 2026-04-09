namespace DailyQuestion
{
    public class XORAfterRangeMultiplicationQueriesII
    {
        public int ComputeXorAfterQueriesWithSqrtOptimization(int[] numbers, int[][] queries)
        {
            int modulo = 1_000_000_007;

            int arrayLength = numbers.Length;

            int sqrtBlockSize = (int)Math.Sqrt(arrayLength) + 1;

            var stepSizeToMultiplicativeDiffArray = new Dictionary<int, long[]>();

            foreach (var query in queries)
            {
                int leftIndex = query[0];
                int rightIndex = query[1];
                int stepSize = query[2];
                int multiplier = query[3];

                if (stepSize <= sqrtBlockSize)
                {
                    if (!stepSizeToMultiplicativeDiffArray.ContainsKey(stepSize))
                    {
                        var multiplicativeDiffArray = new long[arrayLength];

                        for (int index = 0; index < arrayLength; index++)
                        {
                            multiplicativeDiffArray[index] = 1;
                        }

                        stepSizeToMultiplicativeDiffArray[stepSize] = multiplicativeDiffArray;
                    }

                    var currentDiffArray = stepSizeToMultiplicativeDiffArray[stepSize];

                    currentDiffArray[leftIndex] = (currentDiffArray[leftIndex] * multiplier) % modulo;

                    int stoppingIndex = rightIndex + stepSize - ((rightIndex - leftIndex) % stepSize);

                    if (stoppingIndex < arrayLength)
                    {
                        currentDiffArray[stoppingIndex] = (currentDiffArray[stoppingIndex] * ModularInverse(multiplier, modulo)) % modulo;
                    }
                }

                else
                {
                    for (int index = leftIndex; index <= rightIndex; index += stepSize)
                    {
                        numbers[index] = (int)((numbers[index] * (long)multiplier) % modulo);
                    }
                }
            }

            foreach (var entry in stepSizeToMultiplicativeDiffArray)
            {
                int stepSize = entry.Key;
                var multiplicativeDiffArray = entry.Value;

                for (int index = 0; index < arrayLength; index++)
                {
                    if (index - stepSize >= 0)
                    {
                        multiplicativeDiffArray[index] = (multiplicativeDiffArray[index] * multiplicativeDiffArray[index - stepSize]) % modulo;
                    }

                    numbers[index] = (int)((numbers[index] * multiplicativeDiffArray[index]) % modulo);
                }
            }

            int xorResult = 0;

            foreach (int value in numbers)
            {
                xorResult ^= value;
            }

            return xorResult;
        }

        private long ModularInverse(long value, int modulo)
        {
            return FastPower(value, modulo - 2, modulo);
        }

        private long FastPower(long baseValue, long exponent, int modulo)
        {
            long result = 1;
            baseValue %= modulo;

            while (exponent > 0)
            {
                if ((exponent & 1) != 0)
                {
                    result = (result * baseValue) % modulo;
                }

                baseValue = (baseValue * baseValue) % modulo;

                exponent >>= 1;
            }

            return result;
        }
    }
}
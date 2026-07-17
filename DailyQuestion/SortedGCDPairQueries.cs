namespace DailyQuestion
{
    public class SortedGCDPairQueries
    {
        public int[] GcdValues(int[] numbers, long[] queryIndices)
        {
            int maximumValueInArray = 0;

            foreach (int currentNumber in numbers)
            {
                maximumValueInArray = Math.Max(maximumValueInArray, currentNumber);
            }

            int[] frequencyOfEachNumber = new int[maximumValueInArray + 1];

            foreach (int currentNumber in numbers)
            {
                frequencyOfEachNumber[currentNumber]++;
            }

            long[] countOfNumbersDivisibleByValue = new long[maximumValueInArray + 1];

            for (int currentDivisor = 1; currentDivisor <= maximumValueInArray; currentDivisor++)
            {
                for (int currentMultiple = currentDivisor; currentMultiple <= maximumValueInArray; currentMultiple += currentDivisor)
                {
                    countOfNumbersDivisibleByValue[currentDivisor] += frequencyOfEachNumber[currentMultiple];
                }
            }

            long[] numberOfPairsWithExactGcd = new long[maximumValueInArray + 1];

            for (int currentGcd = maximumValueInArray; currentGcd >= 1; currentGcd--)
            {
                long divisibleNumberCount = countOfNumbersDivisibleByValue[currentGcd];

                numberOfPairsWithExactGcd[currentGcd] = divisibleNumberCount * (divisibleNumberCount - 1) / 2;

                for (int largerMultipleOfCurrentGcd = currentGcd * 2; largerMultipleOfCurrentGcd <= maximumValueInArray; largerMultipleOfCurrentGcd += currentGcd)
                {
                    numberOfPairsWithExactGcd[currentGcd] -= numberOfPairsWithExactGcd[largerMultipleOfCurrentGcd];
                }
            }

            long[] cumulativePairCountByGcd = new long[maximumValueInArray + 1];

            for (int currentGcd = 1; currentGcd <= maximumValueInArray; currentGcd++)
            {
                cumulativePairCountByGcd[currentGcd] = cumulativePairCountByGcd[currentGcd - 1] + numberOfPairsWithExactGcd[currentGcd];
            }

            int[] gcdAnswerForEachQuery = new int[queryIndices.Length];

            for (int queryIndex = 0; queryIndex < queryIndices.Length; queryIndex++)
            {
                long targetPairPosition = queryIndices[queryIndex] + 1;

                int minimumPossibleGcd = 1;
                int maximumPossibleGcd = maximumValueInArray;

                while (minimumPossibleGcd < maximumPossibleGcd)
                {
                    int candidateGcd = minimumPossibleGcd + (maximumPossibleGcd - minimumPossibleGcd) / 2;

                    if (cumulativePairCountByGcd[candidateGcd] >= targetPairPosition)
                    {
                        maximumPossibleGcd = candidateGcd;
                    }
                    else
                    {
                        minimumPossibleGcd = candidateGcd + 1;
                    }
                }

                gcdAnswerForEachQuery[queryIndex] = minimumPossibleGcd;
            }

            return gcdAnswerForEachQuery;
        }
    }
}
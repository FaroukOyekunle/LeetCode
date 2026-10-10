namespace DailyQuestion
{
    public class MinimumSumofSquaredDifference
    {
       public long MinSumSquareDiff(int[] firstNumberArray, int[] secondNumberArray, int firstArrayOperationBudget, int secondArrayOperationBudget)
        {
            long remainingDifferenceReductionOperations = (long)firstArrayOperationBudget + secondArrayOperationBudget;

            const int maximumPossibleDifference = 100_000;

            int[] differenceFrequencyByValue = new int[maximumPossibleDifference + 1];

            int largestObservedDifference = 0;

            for (int currentElementIndex = 0; currentElementIndex < firstNumberArray.Length; currentElementIndex++)
            {
                int absoluteDifference = Math.Abs(firstNumberArray[currentElementIndex] - secondNumberArray[currentElementIndex]);

                differenceFrequencyByValue[absoluteDifference]++;

                largestObservedDifference = Math.Max(largestObservedDifference, absoluteDifference);
            }

            for (int currentDifference = largestObservedDifference; currentDifference > 0 && remainingDifferenceReductionOperations > 0; currentDifference--)
            {
                int elementsWithCurrentDifference = differenceFrequencyByValue[currentDifference];

                if (elementsWithCurrentDifference == 0)
                {
                    continue;
                }

                if (remainingDifferenceReductionOperations >= elementsWithCurrentDifference)
                {
                    remainingDifferenceReductionOperations -= elementsWithCurrentDifference;

                    differenceFrequencyByValue[currentDifference] -= elementsWithCurrentDifference;

                    differenceFrequencyByValue[currentDifference - 1] += elementsWithCurrentDifference;
                }
                else
                {
                    int elementsToReduceByOne = (int)remainingDifferenceReductionOperations;

                    differenceFrequencyByValue[currentDifference] -= elementsToReduceByOne;

                    differenceFrequencyByValue[currentDifference - 1] += elementsToReduceByOne;

                    remainingDifferenceReductionOperations = 0;
                }
            }

            long minimumSumOfSquaredDifferences = 0;

            for (int currentDifference = 1; currentDifference <= largestObservedDifference; currentDifference++)
            {
                minimumSumOfSquaredDifferences += (long)differenceFrequencyByValue[currentDifference] * currentDifference * currentDifference;
            }

            return minimumSumOfSquaredDifferences;
        }
    }
}
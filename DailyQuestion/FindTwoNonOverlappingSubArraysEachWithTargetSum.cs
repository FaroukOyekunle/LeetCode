namespace DailyQuestion
{
    public class FindTwoNonOverlappingSubArraysEachWithTargetSum
    {
        public int MinSumOfLengths(int[] numbers, int targetSum)
        {
            int totalNumberCount = numbers.Length;

            int[] shortestSubarrayLengthUpToIndex = new int[totalNumberCount];

            Array.Fill(shortestSubarrayLengthUpToIndex, int.MaxValue);

            int windowStartIndex = 0;
            int currentWindowSum = 0;
            int minimumCombinedSubarrayLength = int.MaxValue;

            for (int windowEndIndex = 0; windowEndIndex < totalNumberCount; windowEndIndex++)
            {
                currentWindowSum += numbers[windowEndIndex];

                while (currentWindowSum > targetSum && windowStartIndex <= windowEndIndex)
                {
                    currentWindowSum -= numbers[windowStartIndex];
                    windowStartIndex++;
                }

                if (currentWindowSum == targetSum)
                {
                    int currentSubarrayLength = windowEndIndex - windowStartIndex + 1;

                    if (windowStartIndex > 0 && shortestSubarrayLengthUpToIndex[windowStartIndex - 1] != int.MaxValue)
                    {
                        minimumCombinedSubarrayLength = Math.Min(minimumCombinedSubarrayLength, currentSubarrayLength + shortestSubarrayLengthUpToIndex[windowStartIndex - 1]);
                    }
                }

                if (windowEndIndex > 0)
                {
                    shortestSubarrayLengthUpToIndex[windowEndIndex] = shortestSubarrayLengthUpToIndex[windowEndIndex - 1];
                }

                if (currentWindowSum == targetSum)
                {
                    int currentSubarrayLength = windowEndIndex - windowStartIndex + 1;

                    shortestSubarrayLengthUpToIndex[windowEndIndex] = Math.Min(shortestSubarrayLengthUpToIndex[windowEndIndex], currentSubarrayLength);
                }
            }

            return minimumCombinedSubarrayLength == int.MaxValue ? -1 : minimumCombinedSubarrayLength;
        }
    }
}
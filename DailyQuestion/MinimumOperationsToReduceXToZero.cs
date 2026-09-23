namespace DailyQuestion
{
    public class MinimumOperationsToReduceXToZero
    {
        public int MinOperations(int[] numbers, int targetRemovalSum)
        {
            int totalArraySum = numbers.Sum();
            int targetRemainingSubarraySum = totalArraySum - targetRemovalSum;

            if (targetRemainingSubarraySum < 0)
            {
                return -1;
            }

            if (targetRemainingSubarraySum == 0)
            {
                return numbers.Length;
            }

            int currentWindowStartIndex = 0;
            int currentWindowSum = 0;
            int longestValidSubarrayLength = -1;

            for (int currentWindowEndIndex = 0; currentWindowEndIndex < numbers.Length; currentWindowEndIndex++)
            {
                currentWindowSum += numbers[currentWindowEndIndex];

                while (currentWindowSum > targetRemainingSubarraySum && currentWindowStartIndex <= currentWindowEndIndex)
                {
                    currentWindowSum -= numbers[currentWindowStartIndex];
                    currentWindowStartIndex++;
                }

                if (currentWindowSum == targetRemainingSubarraySum)
                {
                    int currentValidSubarrayLength = currentWindowEndIndex - currentWindowStartIndex + 1;

                    longestValidSubarrayLength = Math.Max(longestValidSubarrayLength, currentValidSubarrayLength);
                }
            }

            if (longestValidSubarrayLength == -1)
            {
                return -1;
            }

            int minimumOperationsRequired = numbers.Length - longestValidSubarrayLength;

            return minimumOperationsRequired;
        }
    }
}
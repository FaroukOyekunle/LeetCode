namespace DailyQuestion
{
    public class MinimumRemovalstoBalanceArray
    {
        public int CalculateMinimumRemovalsForValidRange(int[] numbers, int multiplierLimit)
        {
            int totalCount = numbers.Length;

            Array.Sort(numbers);

            int windowStartIndex = 0;
            int largestValidWindowSize = 0;

            for (int windowEndIndex = 0; windowEndIndex < totalCount; windowEndIndex++)
            {
                while ((long)numbers[windowEndIndex] > (long)numbers[windowStartIndex] * multiplierLimit)
                {
                    windowStartIndex++;
                }

                int currentWindowSize = windowEndIndex - windowStartIndex + 1;

                largestValidWindowSize = Math.Max(
                    largestValidWindowSize,
                    currentWindowSize
                );
            }

            return totalCount - largestValidWindowSize;
        }

    }
}
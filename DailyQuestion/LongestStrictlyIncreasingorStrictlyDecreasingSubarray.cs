using System;

namespace DailyQuestion
{
    public class LongestStrictlyIncreasingorStrictlyDecreasingSubarray
    {
        public int LongestMonotonicSubarray(int[] numbers)
        {
            int currentIncreasingSubarrayLength = 1;
            int currentDecreasingSubarrayLength = 1;
            int longestMonotonicSubarrayLength = 1;

            for (int currentElementIndex = 1; currentElementIndex < numbers.Length; currentElementIndex++)
            {
                if (numbers[currentElementIndex] > numbers[currentElementIndex - 1])
                {
                    currentIncreasingSubarrayLength++;
                    currentDecreasingSubarrayLength = 1;
                }
                else if (numbers[currentElementIndex] < numbers[currentElementIndex - 1])
                {
                    currentDecreasingSubarrayLength++;
                    currentIncreasingSubarrayLength = 1;
                }
                else
                {
                    currentIncreasingSubarrayLength = 1;
                    currentDecreasingSubarrayLength = 1;
                }

                longestMonotonicSubarrayLength = Math.Max(longestMonotonicSubarrayLength, Math.Max(currentIncreasingSubarrayLength, currentDecreasingSubarrayLength));
            }

            return longestMonotonicSubarrayLength;
        }
    }
}
using System;

namespace DailyQuestion
{
    public class MaximumSubarrayWithEqualProducts
    {

        public int MaxLength(int[] numbers)
        {
            int maximumProductEquivalentSubarrayLength = 0;

            for (int subarrayStartIndex = 0; subarrayStartIndex < numbers.Length; subarrayStartIndex++)
            {
                long currentSubarrayProduct = 1;
                int currentSubarrayGcd = 0;
                long currentSubarrayLcm = 1;

                for (int subarrayEndIndex = subarrayStartIndex; subarrayEndIndex < numbers.Length; subarrayEndIndex++)
                {
                    int currentNumber = numbers[subarrayEndIndex];

                    currentSubarrayProduct *= currentNumber;

                    currentSubarrayGcd = CalculateGreatestCommonDivisor(currentSubarrayGcd, currentNumber);

                    currentSubarrayLcm = CalculateLeastCommonMultiple(currentSubarrayLcm, currentNumber);

                    if (currentSubarrayProduct == currentSubarrayLcm * currentSubarrayGcd)
                    {
                        int currentSubarrayLength = subarrayEndIndex - subarrayStartIndex + 1;

                        maximumProductEquivalentSubarrayLength = Math.Max(maximumProductEquivalentSubarrayLength, currentSubarrayLength);
                    }
                }
            }

            return maximumProductEquivalentSubarrayLength;
        }

        private int CalculateGreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                int remainder = firstNumber % secondNumber;

                firstNumber = secondNumber;
                secondNumber = remainder;
            }

            return firstNumber;
        }

        private long CalculateLeastCommonMultiple(long firstNumber, long secondNumber)
        {
            return (firstNumber / CalculateGreatestCommonDivisor((int)firstNumber, (int)secondNumber)) * secondNumber;
        }
    }
}
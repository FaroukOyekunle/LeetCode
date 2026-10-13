using System;

namespace DailyQuestion
{
    public class MaximumAlternatingSumofSquares
    {
        public long MaxAlternatingSum(int[] numbers)
        {
            Array.Sort(numbers, (firstNumber, secondNumber) => ((long)firstNumber * firstNumber).CompareTo((long)secondNumber * secondNumber));

            long maximumAlternatingSumOfSquares = 0;
            int numberOfNegativeContributions = numbers.Length / 2;

            for (int currentNumberIndex = 0; currentNumberIndex < numbers.Length; currentNumberIndex++)
            {
                long currentNumberSquaredValue = (long)numbers[currentNumberIndex] * numbers[currentNumberIndex];

                maximumAlternatingSumOfSquares += currentNumberIndex < numberOfNegativeContributions ? -currentNumberSquaredValue : currentNumberSquaredValue;
            }

            return maximumAlternatingSumOfSquares;
        }
    }
}
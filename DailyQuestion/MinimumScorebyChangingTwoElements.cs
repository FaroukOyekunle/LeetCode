using System;

namespace DailyQuestion
{
    public class MinimumScorebyChangingTwoElements
    {

        public int MinimizeSum(int[] numbers)
        {
            Array.Sort(numbers);

            int totalNumberOfElements = numbers.Length;

            int minimumScoreAfterRemovingThreeElements = Math.Min(numbers[totalNumberOfElements - 1] - numbers[2],
                Math.Min(numbers[totalNumberOfElements - 2] - numbers[1], numbers[totalNumberOfElements - 3] - numbers[0]));

            return minimumScoreAfterRemovingThreeElements;
        }
    }
}
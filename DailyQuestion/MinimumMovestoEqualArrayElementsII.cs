using System;

namespace DailyQuestion
{
    public class MinimumMovementToEqualArrayElementsII
    {
        public int MinMoves2(int[] numbers)
        {
            Array.Sort(numbers);

            int medianElement = numbers[numbers.Length / 2];

            int totalRequiredMoves = 0;

            foreach (int currentElement in numbers)
            {
                totalRequiredMoves += Math.Abs(currentElement - medianElement);
            }

            return totalRequiredMoves;
        }
    }
}
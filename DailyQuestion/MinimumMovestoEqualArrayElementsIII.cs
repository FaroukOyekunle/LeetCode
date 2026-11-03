using System;
using System.Linq;

namespace DailyQuestion
{
    public class MinimumMovementToEqualArrayElementsIII
    {
        public int MinMoves(int[] numbers)
        {
            int maximumArrayElement = numbers.Max();

            int totalRequiredDecrementOperations = 0;

            foreach (int currentElement in numbers)
            {
                totalRequiredDecrementOperations += maximumArrayElement - currentElement;
            }

            return totalRequiredDecrementOperations;
        }
    }
}
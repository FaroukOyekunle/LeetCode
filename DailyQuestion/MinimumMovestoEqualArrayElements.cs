using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyQuestion
{
    public class MinimumMovementToEqualArrayElements
    {
        public int MinMoves(int[] numbers)
        {
            int minimumArrayElement = numbers.Min();
            int totalRequiredIncrementOperations = 0;

            foreach (int currentElement in numbers)
            {
                totalRequiredIncrementOperations += currentElement - minimumArrayElement;
            }

            return totalRequiredIncrementOperations;
        }
    }
}
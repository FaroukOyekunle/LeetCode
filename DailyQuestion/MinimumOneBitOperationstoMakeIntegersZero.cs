using System.Numerics;

namespace DailyQuestion
{
    public class MinimumOneBitOperationstoMakeIntegersZero
    {
        public int CalculateMinimumBitOperations(int number)
        {
            return CalculateOperationsRecursively(number);
        }

        private int CalculateOperationsRecursively(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            uint unsignedNumber = (uint)number;

            int highestBitPosition = 31 - BitOperations.LeadingZeroCount(unsignedNumber);

            int highestOneBitMask = 1 << highestBitPosition;

            return (1 << (highestBitPosition + 1)) - 1 - CalculateOperationsRecursively(number ^ highestOneBitMask);
        }
    }
}
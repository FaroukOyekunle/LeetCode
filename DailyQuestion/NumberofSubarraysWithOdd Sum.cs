using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class NumberofSubarrayWithOddSum
    {

        public int NumOfSubarrays(int[] arr)
        {
            const int MODULO = 1_000_000_007;

            int oddPrefixSumCount = 0;
            int evenPrefixSumCount = 1;
            int cumulativePrefixSum = 0;
            int totalOddSubarrayCount = 0;

            foreach (int currentElement in arr)
            {
                cumulativePrefixSum += currentElement;

                if (cumulativePrefixSum % 2 == 0)
                {
                    totalOddSubarrayCount += oddPrefixSumCount;
                    evenPrefixSumCount++;
                }
                else
                {
                    totalOddSubarrayCount += evenPrefixSumCount;
                    oddPrefixSumCount++;
                }

                totalOddSubarrayCount %= MODULO;
            }

            return totalOddSubarrayCount;
        }

    }
}
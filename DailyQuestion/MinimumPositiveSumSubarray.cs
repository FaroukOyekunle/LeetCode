using System;
using System.Collections.Generic;

namespace DailyQuestion
{
    public class MinimumPositiveSumSubarray
    {

        public int MinimumSumSubarray(IList<int> nums, int minimumSubarrayLength, int maximumSubarrayLength)
        {
            int minimumPositiveSubarraySum = int.MaxValue;
            int totalNumberOfElements = nums.Count;

            int[] cumulativeSum = new int[totalNumberOfElements + 1];

            for (int elementIndex = 0; elementIndex < totalNumberOfElements; elementIndex++)
            {
                cumulativeSum[elementIndex + 1] = cumulativeSum[elementIndex] + nums[elementIndex];
            }

            for (int currentSubarrayLength = minimumSubarrayLength; currentSubarrayLength <= maximumSubarrayLength; currentSubarrayLength++)
            {
                for (int subarrayStartIndex = 0; subarrayStartIndex + currentSubarrayLength <= totalNumberOfElements; subarrayStartIndex++)
                {
                    int subarrayEndIndex = subarrayStartIndex + currentSubarrayLength;

                    int currentSubarraySum = cumulativeSum[subarrayEndIndex] - cumulativeSum[subarrayStartIndex];

                    if (currentSubarraySum > 0)
                    {
                        minimumPositiveSubarraySum = Math.Min(minimumPositiveSubarraySum, currentSubarraySum);
                    }
                }
            }

            return minimumPositiveSubarraySum == int.MaxValue ? -1 : minimumPositiveSubarraySum;
        }

    }
}
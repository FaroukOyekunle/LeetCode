using System;

namespace DailyQuestion
{
    public class CountNonDecreasingSubarraysAfterKOperations
    {
        public long CountNonDecreasingSubarrays(int[] numbers, int maximumAllowedOperations)
        {
            int totalElementCount = numbers.Length;

            long[] prefixSums = new long[totalElementCount + 1];

            for (int currentElementIndex = 0; currentElementIndex < totalElementCount; currentElementIndex++)
            {
                prefixSums[currentElementIndex + 1] = prefixSums[currentElementIndex] + numbers[currentElementIndex];
            }

            int[] nextGreaterElementIndices = new int[totalElementCount];
            int[] decreasingMonotonicStack = new int[totalElementCount];
            int stackTopIndex = -1;

            for (int currentElementIndex = totalElementCount - 1; currentElementIndex >= 0; currentElementIndex--)
            {
                while (stackTopIndex >= 0 && numbers[decreasingMonotonicStack[stackTopIndex]] <= numbers[currentElementIndex])
                {
                    stackTopIndex--;
                }

                nextGreaterElementIndices[currentElementIndex] = stackTopIndex < 0 ? totalElementCount : decreasingMonotonicStack[stackTopIndex];

                decreasingMonotonicStack[++stackTopIndex] = currentElementIndex;
            }

            int binaryLiftingLevelCount = 1;

            while ((1L << binaryLiftingLevelCount) <= totalElementCount)
            {
                binaryLiftingLevelCount++;
            }

            int[,] nextJumpIndices = new int[binaryLiftingLevelCount, totalElementCount];
            long[,] accumulatedJumpCosts = new long[binaryLiftingLevelCount, totalElementCount];

            for (int elementIndex = 0; elementIndex < totalElementCount; elementIndex++)
            {
                int nextGreaterElementIndex = nextGreaterElementIndices[elementIndex];

                nextJumpIndices[0, elementIndex] = nextGreaterElementIndex;

                accumulatedJumpCosts[0, elementIndex] = (long)numbers[elementIndex] * (nextGreaterElementIndex - elementIndex) - (prefixSums[nextGreaterElementIndex] - prefixSums[elementIndex]);
            }

            for (int liftingLevel = 1; liftingLevel < binaryLiftingLevelCount; liftingLevel++)
            {
                for (int elementIndex = 0; elementIndex < totalElementCount; elementIndex++)
                {
                    int intermediateJumpIndex = nextJumpIndices[liftingLevel - 1, elementIndex];

                    if (intermediateJumpIndex == totalElementCount)
                    {
                        nextJumpIndices[liftingLevel, elementIndex] = totalElementCount;

                        accumulatedJumpCosts[liftingLevel, elementIndex] = accumulatedJumpCosts[liftingLevel - 1, elementIndex];
                    }
                    else
                    {
                        nextJumpIndices[liftingLevel, elementIndex] = nextJumpIndices[liftingLevel - 1, intermediateJumpIndex];

                        accumulatedJumpCosts[liftingLevel, elementIndex] = accumulatedJumpCosts[liftingLevel - 1, elementIndex] + accumulatedJumpCosts[liftingLevel - 1, intermediateJumpIndex];
                    }
                }
            }

            long CalculateRequiredOperations(int subarrayStartIndex, int subarrayEndIndex)
            {
                long totalRequiredOperations = 0;
                int currentElementIndex = subarrayStartIndex;

                for (int liftingLevel = binaryLiftingLevelCount - 1; liftingLevel >= 0; liftingLevel--)
                {
                    int nextJumpIndex = nextJumpIndices[liftingLevel, currentElementIndex];

                    if (nextJumpIndex <= subarrayEndIndex)
                    {
                        totalRequiredOperations += accumulatedJumpCosts[liftingLevel, currentElementIndex];

                        currentElementIndex = nextJumpIndex;
                    }
                }

                totalRequiredOperations += (long)numbers[currentElementIndex] * (subarrayEndIndex - currentElementIndex + 1) - (prefixSums[subarrayEndIndex + 1] - prefixSums[currentElementIndex]);

                return totalRequiredOperations;
            }

            long totalValidSubarrayCount = 0;

            for (int subarrayStartIndex = 0; subarrayStartIndex < totalElementCount; subarrayStartIndex++)
            {
                int searchStartIndex = subarrayStartIndex;
                int searchEndIndex = totalElementCount - 1;
                int rightmostValidEndIndex = subarrayStartIndex - 1;

                while (searchStartIndex <= searchEndIndex)
                {
                    int middleEndIndex = searchStartIndex + (searchEndIndex - searchStartIndex) / 2;

                    long requiredOperations = CalculateRequiredOperations(subarrayStartIndex, middleEndIndex);

                    if (requiredOperations <= maximumAllowedOperations)
                    {
                        rightmostValidEndIndex = middleEndIndex;
                        searchStartIndex = middleEndIndex + 1;
                    }
                    else
                    {
                        searchEndIndex = middleEndIndex - 1;
                    }
                }

                totalValidSubarrayCount +=rightmostValidEndIndex - subarrayStartIndex + 1;
            }

            return totalValidSubarrayCount;
        }
    }
}
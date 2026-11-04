using System;
using System.Linq;

namespace DailyQuestion
{
    public class MinimumOperationsToMakeElementsWithinKSubarraysEqual
    {
        public long MinOperations(int[] numbers, int subarrayLength, int requiredSubarrayCount)
        {
            int totalElementCount = numbers.Length;

            int[] sortedDistinctValues = numbers.Distinct().OrderBy(value => value).ToArray();

            int[] compressedValueIndices = new int[totalElementCount];

            for (int elementIndex = 0; elementIndex < totalElementCount; elementIndex++)
            {
                compressedValueIndices[elementIndex] = Array.BinarySearch(sortedDistinctValues, numbers[elementIndex]);
            }

            var frequencyTree = new FenwickTree(sortedDistinctValues.Length);
            var prefixSumTree = new FenwickTree(sortedDistinctValues.Length);

            long currentWindowSum = 0;

            for (int elementIndex = 0; elementIndex < subarrayLength; elementIndex++)
            {
                int compressedValueIndex = compressedValueIndices[elementIndex];

                frequencyTree.Add(compressedValueIndex, 1);
                prefixSumTree.Add(compressedValueIndex, numbers[elementIndex]);

                currentWindowSum += numbers[elementIndex];
            }

            long[] minimumWindowAdjustmentCosts = new long[totalElementCount - subarrayLength + 1];

            minimumWindowAdjustmentCosts[0] = GetWindowCost(subarrayLength, currentWindowSum, sortedDistinctValues, frequencyTree, prefixSumTree);

            for (int windowStartIndex = 1; windowStartIndex <= totalElementCount - subarrayLength; windowStartIndex++)
            {
                int outgoingCompressedValueIndex = compressedValueIndices[windowStartIndex - 1];
                int outgoingElementValue = numbers[windowStartIndex - 1];

                frequencyTree.Add(outgoingCompressedValueIndex, -1);
                prefixSumTree.Add(outgoingCompressedValueIndex, -outgoingElementValue);

                currentWindowSum -= outgoingElementValue;

                int incomingElementIndex = windowStartIndex + subarrayLength - 1;
                int incomingCompressedValueIndex = compressedValueIndices[incomingElementIndex];
                int incomingElementValue = numbers[incomingElementIndex];

                frequencyTree.Add(incomingCompressedValueIndex, 1);
                prefixSumTree.Add(incomingCompressedValueIndex, incomingElementValue);

                currentWindowSum += incomingElementValue;

                minimumWindowAdjustmentCosts[windowStartIndex] = GetWindowCost(subarrayLength, currentWindowSum, sortedDistinctValues, frequencyTree, prefixSumTree);
            }

            long infinity = long.MaxValue / 2;

            long[] previousSubarrayCosts = new long[totalElementCount + 1];
            long[] currentSubarrayCosts = new long[totalElementCount + 1];

            for (int selectedSubarrayCount = 1; selectedSubarrayCount <= requiredSubarrayCount; selectedSubarrayCount++)
            {
                Array.Fill(currentSubarrayCosts, infinity);

                for (int prefixElementCount = subarrayLength;  prefixElementCount <= totalElementCount; prefixElementCount++)
                {
                    currentSubarrayCosts[prefixElementCount] = currentSubarrayCosts[prefixElementCount - 1];

                    int candidateWindowStartIndex = prefixElementCount - subarrayLength;

                    if (previousSubarrayCosts[candidateWindowStartIndex] != infinity)
                    {
                        long costOfSelectingCurrentWindow = previousSubarrayCosts[candidateWindowStartIndex] + minimumWindowAdjustmentCosts[candidateWindowStartIndex];

                        currentSubarrayCosts[prefixElementCount] = Math.Min(currentSubarrayCosts[prefixElementCount], costOfSelectingCurrentWindow);
                    }
                }

                (previousSubarrayCosts, currentSubarrayCosts) = (currentSubarrayCosts, previousSubarrayCosts);
            }

            return previousSubarrayCosts[totalElementCount];
        }

        private long GetWindowCost(int windowLength, long windowElementSum, int[] sortedDistinctValues, FenwickTree frequencyTree, FenwickTree prefixSumTree)
        {
            int medianValueIndex = frequencyTree.FindByOrder((windowLength + 1) / 2);

            long medianValue = sortedDistinctValues[medianValueIndex];

            long leftSideElementCount = frequencyTree.Query(medianValueIndex + 1);
            long leftSideElementSum = prefixSumTree.Query(medianValueIndex + 1);

            long rightSideElementCount = windowLength - leftSideElementCount;
            long rightSideElementSum = windowElementSum - leftSideElementSum;

            long leftSideAdjustmentCost = medianValue * leftSideElementCount - leftSideElementSum;

            long rightSideAdjustmentCost = rightSideElementSum - medianValue * rightSideElementCount;

            return leftSideAdjustmentCost + rightSideAdjustmentCost;
        }

        private class FenwickTree
        {
            private readonly long[] tree;
            private readonly int treeSize;

            public FenwickTree(int elementCount)
            {
                treeSize = elementCount;
                tree = new long[elementCount + 1];
            }

            public void Add(int compressedIndex, long valueToAdd)
            {
                int treeIndex = compressedIndex + 1;

                while (treeIndex <= treeSize)
                {
                    tree[treeIndex] += valueToAdd;
                    treeIndex += treeIndex & -treeIndex;
                }
            }

            public long Query(int prefixElementCount)
            {
                long prefixSum = 0;

                while (prefixElementCount > 0)
                {
                    prefixSum += tree[prefixElementCount];
                    prefixElementCount -= prefixElementCount & -prefixElementCount;
                }

                return prefixSum;
            }

            public int FindByOrder(int targetCumulativeFrequency)
            {
                int currentTreeIndex = 0;

                int highestPowerOfTwo = 1;

                while (highestPowerOfTwo <= treeSize / 2)
                {
                    highestPowerOfTwo <<= 1;
                }

                while (highestPowerOfTwo > 0)
                {
                    int candidateTreeIndex = currentTreeIndex + highestPowerOfTwo;

                    if (candidateTreeIndex <= treeSize && tree[candidateTreeIndex] < targetCumulativeFrequency)
                    {
                        currentTreeIndex = candidateTreeIndex;
                        targetCumulativeFrequency -= (int)tree[candidateTreeIndex];
                    }

                    highestPowerOfTwo >>= 1;
                }

                return currentTreeIndex;
            }
        }
    }
}
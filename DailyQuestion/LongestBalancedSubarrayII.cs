namespace DailyQuestion
{
    public class LongestBalancedSubarrayII
    {
        public int CalculateLongestBalancedSubarrayLength(int[] inputNumbers)
        {
            int segmentTreeCapacity = inputNumbers.Length + 1;

            var prefixBalanceSegmentTree = new PrefixBalanceSegmentTree(segmentTreeCapacity);

            int longestBalancedSubarrayLength = 0;

            int currentPrefixBalance = 0;

            var lastSeenIndexByNumber = new Dictionary<int, int>();

            for (int currentIndex = 1; currentIndex <= inputNumbers.Length; currentIndex++)
            {
                int currentNumber = inputNumbers[currentIndex - 1];

                int balanceContribution = (currentNumber & 1) == 1 ? +1 : -1;

                if (lastSeenIndexByNumber.ContainsKey(currentNumber))
                {
                    int previousIndex = lastSeenIndexByNumber[currentNumber];

                    prefixBalanceSegmentTree.UpdateRange(previousIndex, segmentTreeCapacity - 1, -balanceContribution);

                    currentPrefixBalance -= balanceContribution;
                }

                currentPrefixBalance += balanceContribution;

                lastSeenIndexByNumber[currentNumber] = currentIndex;

                prefixBalanceSegmentTree.UpdateRange(currentIndex, segmentTreeCapacity - 1, balanceContribution);

                int earliestMatchingIndex = prefixBalanceSegmentTree.FindFirstIndexMatchingBalance(currentPrefixBalance);

                int currentBalancedSubarrayLength = currentIndex - earliestMatchingIndex;

                longestBalancedSubarrayLength = Math.Max(longestBalancedSubarrayLength, currentBalancedSubarrayLength);
            }

            return longestBalancedSubarrayLength;
        }


        private class PrefixBalanceSegmentTree
        {
            private int treeLeafBaseIndex;

            private int[] lazyPropagationValues;

            public int[] minimumBalancePerNode;
            public int[] maximumBalancePerNode;

            public PrefixBalanceSegmentTree(int requiredCapacity)
            {
                treeLeafBaseIndex = 1;

                while (treeLeafBaseIndex < requiredCapacity)
                {
                    treeLeafBaseIndex <<= 1;
                }

                lazyPropagationValues = new int[treeLeafBaseIndex];
                minimumBalancePerNode = new int[treeLeafBaseIndex << 1];
                maximumBalancePerNode = new int[treeLeafBaseIndex << 1];
            }

            private void ApplyDeltaToNode(int nodeIndex, int deltaValue)
            {
                minimumBalancePerNode[nodeIndex] += deltaValue;
                maximumBalancePerNode[nodeIndex] += deltaValue;

                if (nodeIndex < treeLeafBaseIndex)
                {
                    lazyPropagationValues[nodeIndex] += deltaValue;
                }
            }

            private void RecalculateAncestors(int nodeIndex)
            {
                while (nodeIndex > 1)
                {
                    nodeIndex >>= 1;

                    minimumBalancePerNode[nodeIndex] =
                        Math.Min(minimumBalancePerNode[nodeIndex << 1], minimumBalancePerNode[(nodeIndex << 1) | 1]);

                    maximumBalancePerNode[nodeIndex] =
                        Math.Max(maximumBalancePerNode[nodeIndex << 1], maximumBalancePerNode[(nodeIndex << 1) | 1]);

                    if (lazyPropagationValues[nodeIndex] != 0)
                    {
                        minimumBalancePerNode[nodeIndex] += lazyPropagationValues[nodeIndex];
                        maximumBalancePerNode[nodeIndex] += lazyPropagationValues[nodeIndex];
                    }
                }
            }

            public void UpdateRange(int rangeStartIndex, int rangeEndIndex, int deltaValue)
            {
                int leftPointer = rangeStartIndex + treeLeafBaseIndex;
                int rightPointer = rangeEndIndex + treeLeafBaseIndex;

                int originalLeftPointer = leftPointer;
                int originalRightPointer = rightPointer;

                while (leftPointer <= rightPointer)
                {
                    if ((leftPointer & 1) == 1)
                    {
                        ApplyDeltaToNode(leftPointer, deltaValue);
                        leftPointer++;
                    }

                    if ((rightPointer & 1) == 0)
                    {
                        ApplyDeltaToNode(rightPointer, deltaValue);
                        rightPointer--;
                    }

                    leftPointer >>= 1;
                    rightPointer >>= 1;
                }

                RecalculateAncestors(originalLeftPointer);
                RecalculateAncestors(originalRightPointer);
            }

            public int FindFirstIndexMatchingBalance(int targetBalance)
            {
                int currentNodeIndex = 1;

                while (currentNodeIndex < treeLeafBaseIndex)
                {
                    if (lazyPropagationValues[currentNodeIndex] != 0)
                    {
                        ApplyDeltaToNode(currentNodeIndex << 1, lazyPropagationValues[currentNodeIndex]);
                        ApplyDeltaToNode((currentNodeIndex << 1) | 1, lazyPropagationValues[currentNodeIndex]);
                        lazyPropagationValues[currentNodeIndex] = 0;
                    }

                    currentNodeIndex <<= 1;

                    if (!(minimumBalancePerNode[currentNodeIndex] <= targetBalance && targetBalance <= maximumBalancePerNode[currentNodeIndex]))
                    {
                        currentNodeIndex |= 1;
                    }
                }

                return currentNodeIndex - treeLeafBaseIndex;
            }
        }
    }
}
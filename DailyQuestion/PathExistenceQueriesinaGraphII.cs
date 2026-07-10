namespace DailyQuestion
{
    public class PathExistenceQueriesinaGraphII
    {
        private const int MaximumBinaryLiftingPower = 20;

        public int[] PathExistenceQueries(int nodeCount, int[] nodeValues, int maximumAllowedDifference, int[][] queries)
        {
            var nodesSortedByValue = new (int Value, int OriginalIndex)[nodeCount];

            for (int currentNodeIndex = 0; currentNodeIndex < nodeCount; currentNodeIndex++)
            {
                nodesSortedByValue[currentNodeIndex] =
                (
                    nodeValues[currentNodeIndex],
                    currentNodeIndex
                );
            }

            Array.Sort(nodesSortedByValue, (leftNode, rightNode) => leftNode.Value.CompareTo(rightNode.Value));

            int[,] binaryLiftingJumpTable = new int[nodeCount, MaximumBinaryLiftingPower];

            int farthestReachableSortedIndex = nodeCount - 1;

            for (int currentSortedIndex = nodeCount - 1; currentSortedIndex >= 0; currentSortedIndex--)
            {
                while (nodesSortedByValue[farthestReachableSortedIndex].Value - nodesSortedByValue[currentSortedIndex].Value > maximumAllowedDifference)
                {
                    farthestReachableSortedIndex--;
                }

                int currentOriginalNodeIndex = nodesSortedByValue[currentSortedIndex].OriginalIndex;

                int farthestReachableOriginalNodeIndex = nodesSortedByValue[farthestReachableSortedIndex].OriginalIndex;

                binaryLiftingJumpTable[currentOriginalNodeIndex, 0] = farthestReachableOriginalNodeIndex;

                for (int binaryLiftPower = 1; binaryLiftPower < MaximumBinaryLiftingPower; binaryLiftPower++)
                {
                    binaryLiftingJumpTable[currentOriginalNodeIndex, binaryLiftPower] = binaryLiftingJumpTable[binaryLiftingJumpTable[currentOriginalNodeIndex, binaryLiftPower - 1], binaryLiftPower - 1];
                }
            }

            int[] minimumStepCounts = new int[queries.Length];

            for (int queryIndex = 0; queryIndex < queries.Length; queryIndex++)
            {
                int sourceNodeIndex = queries[queryIndex][0];
                int destinationNodeIndex = queries[queryIndex][1];

                if (nodeValues[sourceNodeIndex] > nodeValues[destinationNodeIndex])
                {
                    (sourceNodeIndex, destinationNodeIndex) = (destinationNodeIndex, sourceNodeIndex);
                }

                if (sourceNodeIndex == destinationNodeIndex)
                {
                    minimumStepCounts[queryIndex] = 0;
                    continue;
                }

                if (nodeValues[sourceNodeIndex] == nodeValues[destinationNodeIndex])
                {
                    minimumStepCounts[queryIndex] = 1;
                    continue;
                }

                int minimumRequiredSteps = 0;

                for (int binaryLiftPower = MaximumBinaryLiftingPower - 1; binaryLiftPower >= 0; binaryLiftPower--)
                {
                    int reachableNodeIndex = binaryLiftingJumpTable[sourceNodeIndex, binaryLiftPower];

                    if (nodeValues[reachableNodeIndex] < nodeValues[destinationNodeIndex])
                    {
                        minimumRequiredSteps += 1 << binaryLiftPower;

                        sourceNodeIndex = reachableNodeIndex;
                    }
                }

                if (nodeValues[binaryLiftingJumpTable[sourceNodeIndex, 0]] < nodeValues[destinationNodeIndex])
                {
                    minimumStepCounts[queryIndex] = -1;
                }
                else
                {
                    minimumStepCounts[queryIndex] = minimumRequiredSteps + 1;
                }
            }

            return minimumStepCounts;
        }
    }
}
namespace DailyQuestion
{
    public class BlockPlacementQueries
    {
        public IList<bool> GetResults(int[][] queries)
        {
            const int MaximumPosition = 50000;

            bool[] obstaclePresenceMap = new bool[MaximumPosition + 1];

            foreach (int[] query in queries)
            {
                if (query[0] == 1)
                {
                    int obstaclePosition = query[1];
                    obstaclePresenceMap[obstaclePosition] = true;
                }
            }

            FenwickTree obstacleCountTree = new FenwickTree(MaximumPosition + 2);

            SegmentTree maximumGapTree = new SegmentTree(MaximumPosition + 1);

            obstacleCountTree.Add(0, 1);

            List<int> obstaclePositions = new List<int> { 0 };

            for (int position = 1; position <= MaximumPosition; position++)
            {
                if (obstaclePresenceMap[position])
                {
                    obstacleCountTree.Add(position, 1);
                    obstaclePositions.Add(position);
                }
            }

            for (int obstacleIndex = 1; obstacleIndex < obstaclePositions.Count; obstacleIndex++)
            {
                int currentObstaclePosition = obstaclePositions[obstacleIndex];

                int previousObstaclePosition = obstaclePositions[obstacleIndex - 1];

                int gapLength = currentObstaclePosition - previousObstaclePosition;

                maximumGapTree.Update(currentObstaclePosition, gapLength);
            }

            List<bool> queryResults = new List<bool>();

            for (int queryIndex = queries.Length - 1; queryIndex >= 0; queryIndex--)
            {
                int[] currentQuery = queries[queryIndex];

                if (currentQuery[0] == 2)
                {
                    int targetPosition = currentQuery[1];
                    int requiredBlockSize = currentQuery[2];

                    int nearestObstacleOnLeft = GetNearestObstacleAtOrBeforePosition(obstacleCountTree, targetPosition);

                    int largestCompletedGapBeforePosition = maximumGapTree.Query(0, targetPosition);

                    int trailingGapLength = targetPosition - nearestObstacleOnLeft;

                    int largestAvailableGap = Math.Max(largestCompletedGapBeforePosition, trailingGapLength);

                    queryResults.Add(largestAvailableGap >= requiredBlockSize);
                }
                else
                {
                    int removedObstaclePosition = currentQuery[1];

                    int leftNeighborObstacle = GetNearestObstacleAtOrBeforePosition(obstacleCountTree, removedObstaclePosition - 1);

                    int rightNeighborObstacle = GetNextObstacleAfterPosition(obstacleCountTree, removedObstaclePosition);

                    maximumGapTree.Update(removedObstaclePosition, 0);

                    if (rightNeighborObstacle != -1)
                    {
                        int mergedGapLength = rightNeighborObstacle - leftNeighborObstacle;

                        maximumGapTree.Update(rightNeighborObstacle, mergedGapLength);
                    }

                    obstacleCountTree.Add(removedObstaclePosition, -1);
                }
            }

            queryResults.Reverse();

            return queryResults;
        }

        private static int GetNearestObstacleAtOrBeforePosition(FenwickTree obstacleCountTree, int targetPosition)
        {
            if (targetPosition < 0)
            {
                return 0;
            }

            int obstacleCountUpToPosition = obstacleCountTree.Sum(targetPosition);

            return obstacleCountTree.FindPositionByOrder(obstacleCountUpToPosition);
        }

        private static int GetNextObstacleAfterPosition(FenwickTree obstacleCountTree, int currentPosition)
        {
            int obstacleRankAtPosition = obstacleCountTree.Sum(currentPosition);

            int totalObstacleCount =obstacleCountTree.Sum(50000);

            if (obstacleRankAtPosition == totalObstacleCount)
            {
                return -1;
            }

            return obstacleCountTree.FindPositionByOrder(obstacleRankAtPosition + 1);
        }

        public class FenwickTree
        {
            private readonly int[] binaryIndexedTree;
            private readonly int treeSize;

            public FenwickTree(int maximumSize)
            {
                treeSize = maximumSize;
                binaryIndexedTree = new int[maximumSize + 2];
            }

            public void Add(int position, int valueToAdd)
            {
                position++;

                while (position < binaryIndexedTree.Length)
                {
                    binaryIndexedTree[position] += valueToAdd;

                    position += position & -position;
                }
            }

            public int Sum(int position)
            {
                position++;

                int prefixSum = 0;

                while (position > 0)
                {
                    prefixSum += binaryIndexedTree[position];

                    position -= position & -position;
                }

                return prefixSum;
            }

            public int FindPositionByOrder(int targetOrder)
            {
                int currentPosition = 0;

                int highestPowerOfTwo = 1;

                while ((highestPowerOfTwo << 1) < binaryIndexedTree.Length)
                {
                    highestPowerOfTwo <<= 1;
                }

                for (int stepSize = highestPowerOfTwo; stepSize > 0; stepSize >>= 1)
                {
                    int candidatePosition = currentPosition + stepSize;

                    if (candidatePosition < binaryIndexedTree.Length && binaryIndexedTree[candidatePosition] <  targetOrder)
                    {
                        targetOrder -= binaryIndexedTree[candidatePosition];

                        currentPosition = candidatePosition;
                    }
                }

                return currentPosition;
            }
        }

        public class SegmentTree
        {
            private readonly int[] maximumValueTree;
            private readonly int treeBaseSize;

            public SegmentTree(int elementCount)
            {
                treeBaseSize = 1;

                while (treeBaseSize < elementCount)
                {
                    treeBaseSize <<= 1;
                }

                maximumValueTree = new int[treeBaseSize << 1];
            }

            public void Update(int position, int newValue)
            {
                int treeNodeIndex = position + treeBaseSize;

                maximumValueTree[treeNodeIndex] = newValue;

                treeNodeIndex >>= 1;

                while (treeNodeIndex > 0)
                {
                    maximumValueTree[treeNodeIndex] = Math.Max(maximumValueTree[treeNodeIndex << 1], maximumValueTree[(treeNodeIndex << 1) | 1]);

                    treeNodeIndex >>= 1;
                }
            }

            public int Query(int leftBoundary, int rightBoundary)
            {
                int maximumValueInRange = 0;

                leftBoundary += treeBaseSize;
                rightBoundary += treeBaseSize;

                while (leftBoundary <= rightBoundary)
                {
                    if ((leftBoundary & 1) == 1)
                    {
                        maximumValueInRange = Math.Max(maximumValueInRange, maximumValueTree[leftBoundary++]);
                    }

                    if ((rightBoundary & 1) == 0)
                    {
                        maximumValueInRange = Math.Max(maximumValueInRange, maximumValueTree[rightBoundary--]);
                    }

                    leftBoundary >>= 1;
                    rightBoundary >>= 1;
                }

                return maximumValueInRange;
            }
        }
    }
}
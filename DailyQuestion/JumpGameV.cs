namespace DailyQuestion
{
    public class JumpGameV
    {
        public int MaxJumps(int[] heights, int maximumAllowedJumpDistance)
        {
            int totalIndices = heights.Length;

            int[] maximumJumpsFromEachIndexCache = new int[totalIndices];

            int overallMaximumReachableIndices = 1;

            for (int startingIndex = 0; startingIndex < totalIndices; startingIndex++)
            {
                overallMaximumReachableIndices = Math.Max(overallMaximumReachableIndices, 
                CalculateMaximumReachableIndices(startingIndex, heights, maximumAllowedJumpDistance, maximumJumpsFromEachIndexCache));
            }

            return overallMaximumReachableIndices;
        }

        private int CalculateMaximumReachableIndices(int currentIndex, int[] heights, int maximumAllowedJumpDistance, int[] maximumJumpsFromEachIndexCache)
        {
            bool hasPreviouslyCalculatedResult = maximumJumpsFromEachIndexCache[currentIndex] != 0;

            if (hasPreviouslyCalculatedResult)
            {
                return maximumJumpsFromEachIndexCache[currentIndex];
            }

            int maximumReachableIndicesCount = 1;

            int rightBoundaryIndex = Math.Min(currentIndex + maximumAllowedJumpDistance, heights.Length - 1);

            for (int nextRightIndex = currentIndex + 1; nextRightIndex <= rightBoundaryIndex; nextRightIndex++)
            {
                bool encounteredBlockingHeight = heights[nextRightIndex] >= heights[currentIndex];

                if (encounteredBlockingHeight)
                {
                    break;
                }

                maximumReachableIndicesCount = Math.Max(maximumReachableIndicesCount,
                    1 + CalculateMaximumReachableIndices(nextRightIndex, heights, maximumAllowedJumpDistance, maximumJumpsFromEachIndexCache));
            }

            int leftBoundaryIndex = Math.Max(currentIndex - maximumAllowedJumpDistance, 0);

            for (int nextLeftIndex = currentIndex - 1; nextLeftIndex >= leftBoundaryIndex; nextLeftIndex--)
            {
                bool encounteredBlockingHeight = heights[nextLeftIndex] >= heights[currentIndex];

                if (encounteredBlockingHeight)
                {
                    break;
                }

                maximumReachableIndicesCount = Math.Max(
                    maximumReachableIndicesCount, 1 + CalculateMaximumReachableIndices(nextLeftIndex, heights, maximumAllowedJumpDistance, maximumJumpsFromEachIndexCache));
            }

            maximumJumpsFromEachIndexCache[currentIndex] = maximumReachableIndicesCount;

            return maximumReachableIndicesCount;
        }
    }
}
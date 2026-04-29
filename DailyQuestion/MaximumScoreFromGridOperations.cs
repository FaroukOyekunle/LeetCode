namespace DailyQuestion
{
    public class MaximumScoreFromGridOperations
    {
        public long MaximumScore(int[][] scoreGrid)
        {
            int gridSize = scoreGrid.Length;

            long[] previousColumnPrefixSum = new long[gridSize + 1];
            for (int rowIndex = 0; rowIndex < gridSize; rowIndex++)
            {
                previousColumnPrefixSum[rowIndex + 1] = previousColumnPrefixSum[rowIndex] + scoreGrid[rowIndex][0];
            }

            long[][] dpStates = new long[2][];
            dpStates[0] = new long[gridSize + 1];
            dpStates[1] = new long[gridSize + 1];

            for (int columnIndex = 1; columnIndex < gridSize; columnIndex++)
            {
                long[] currentColumnPrefixSum = new long[gridSize + 1];
                for (int rowIndex = 0; rowIndex < gridSize; rowIndex++)
                {
                    currentColumnPrefixSum[rowIndex + 1] = currentColumnPrefixSum[rowIndex] + scoreGrid[rowIndex][columnIndex];
                }

                long[][] nextDpStates = new long[2][];
                nextDpStates[0] = new long[gridSize + 1];
                nextDpStates[1] = new long[gridSize + 1];

                long maxPreviousBottomState = 0;
                for (int splitIndex = 0; splitIndex <= gridSize; splitIndex++)
                {
                    maxPreviousBottomState = Math.Max(maxPreviousBottomState, dpStates[1][splitIndex]);
                }

                for (int currentSplitIndex = 0; currentSplitIndex <= gridSize; currentSplitIndex++)
                {
                    for (int previousSplitIndex = 0; previousSplitIndex <= currentSplitIndex; previousSplitIndex++)
                    {
                        long segmentSum = previousColumnPrefixSum[currentSplitIndex] - previousColumnPrefixSum[previousSplitIndex];

                        nextDpStates[0][currentSplitIndex] = Math.Max(nextDpStates[0][currentSplitIndex], segmentSum + dpStates[0][previousSplitIndex]);
                    }

                    nextDpStates[0][currentSplitIndex] = Math.Max(nextDpStates[0][currentSplitIndex], maxPreviousBottomState);

                    for (int nextSplitIndex = currentSplitIndex + 1; nextSplitIndex <= gridSize; nextSplitIndex++)
                    {
                        long segmentSum = currentColumnPrefixSum[nextSplitIndex] - currentColumnPrefixSum[currentSplitIndex];

                        nextDpStates[1][currentSplitIndex] = Math.Max(nextDpStates[1][currentSplitIndex], dpStates[1][nextSplitIndex] + segmentSum);
                    }

                    nextDpStates[1][currentSplitIndex] = Math.Max(nextDpStates[1][currentSplitIndex], nextDpStates[0][currentSplitIndex]);
                }

                dpStates = nextDpStates;
                previousColumnPrefixSum = currentColumnPrefixSum;
            }

            long maximumAchievableScore = 0;

            for (int splitIndex = 0; splitIndex <= gridSize; splitIndex++)
            {
                maximumAchievableScore = Math.Max(maximumAchievableScore, dpStates[1][splitIndex]);
            }

            return maximumAchievableScore;
        }
    }
}
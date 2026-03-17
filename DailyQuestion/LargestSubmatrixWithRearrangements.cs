namespace DailyQuestion
{
    public class LargestSubmatrixWithRearrangements
    {
        public int FindLargestSubmatrixWithRearrangedColumns(int[][] binaryMatrix)
        {
            int totalRows = binaryMatrix.Length;
            int totalColumns = binaryMatrix[0].Length;

            int[][] consecutiveOnesHeightMatrix = new int[totalRows][];

            for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                consecutiveOnesHeightMatrix[rowIndex] = new int[totalColumns];
            }

            for (int columnIndex = 0; columnIndex < totalColumns; columnIndex++)
            {
                consecutiveOnesHeightMatrix[0][columnIndex] = binaryMatrix[0][columnIndex];

                for (int rowIndex = 1; rowIndex < totalRows; rowIndex++)
                {
                    if (binaryMatrix[rowIndex][columnIndex] == 0)
                    {
                        consecutiveOnesHeightMatrix[rowIndex][columnIndex] = 0;
                    }
                    else
                    {
                        consecutiveOnesHeightMatrix[rowIndex][columnIndex] = consecutiveOnesHeightMatrix[rowIndex - 1][columnIndex] + 1;
                    }
                }
            }

            int maximumSubmatrixArea = 0;

            for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
            {
                int[] sortedHeightsDescending = new int[totalColumns];
                Array.Copy(consecutiveOnesHeightMatrix[rowIndex], sortedHeightsDescending, totalColumns);

                Array.Sort(sortedHeightsDescending);
                Array.Reverse(sortedHeightsDescending);

                for (int columnCount = 0; columnCount < totalColumns; columnCount++)
                {
                    int currentHeight = sortedHeightsDescending[columnCount];
                    int currentWidth = columnCount + 1;

                    int currentArea = currentHeight * currentWidth;

                    maximumSubmatrixArea = Math.Max(maximumSubmatrixArea, currentArea);
                }
            }

            return maximumSubmatrixArea;
        }
    }
}
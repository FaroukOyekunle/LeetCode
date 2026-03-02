namespace DailyQuestion
{
    public class MinimumSwapstoArrangeaBinaryGrid
    {
        public int CalculateMinimumSwapsToArrangeBinaryGrid(int[][] binaryGrid)
        {
            int gridSize = binaryGrid.Length;
            int[] trailingZeroCounts = new int[gridSize];

            for (int rowIndex = 0; rowIndex < gridSize; rowIndex++)
            {
                int zeroCount = 0;
                for (int columnIndex = gridSize - 1; columnIndex >= 0 && binaryGrid[rowIndex][columnIndex] == 0; columnIndex--)
                {
                    zeroCount++;
                }

                trailingZeroCounts[rowIndex] = zeroCount;
            }

            int totalSwaps = 0;

            for (int currentRow = 0; currentRow < gridSize; currentRow++)
            {
                int requiredTrailingZeros = gridSize - 1 - currentRow;
                int targetRow = currentRow;

                while (targetRow < gridSize && trailingZeroCounts[targetRow] < requiredTrailingZeros)
                {
                    targetRow++;
                }

                if (targetRow == gridSize)
                {
                    return -1; 
                }

                while (targetRow > currentRow)
                {
                    int temp = trailingZeroCounts[targetRow];
                    trailingZeroCounts[targetRow] = trailingZeroCounts[targetRow - 1];
                    trailingZeroCounts[targetRow - 1] = temp;

                    totalSwaps++;
                    targetRow--;
                }
            }

            return totalSwaps;
        }
    }
}
namespace DailyQuestion
{
    public class LargestMagicSquare
    {
        public int LargestMagicSquare(int[][] grid)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            int[][] rowPrefixSum = new int[rowCount][];
            int[][] columnPrefixSum = new int[rowCount][];
            int[][] mainDiagonalPrefixSum = new int[rowCount][];
            int[][] antiDiagonalPrefixSum = new int[rowCount][];

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                rowPrefixSum[rowIndex] = new int[columnCount + 1];
                columnPrefixSum[rowIndex] = new int[columnCount + 1];
                mainDiagonalPrefixSum[rowIndex] = new int[columnCount + 1];
                antiDiagonalPrefixSum[rowIndex] = new int[columnCount + 1];
            }

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    rowPrefixSum[rowIndex][columnIndex + 1] = rowPrefixSum[rowIndex][columnIndex] + grid[rowIndex][columnIndex];
                    columnPrefixSum[rowIndex][columnIndex + 1] = columnPrefixSum[rowIndex][columnIndex] + grid[columnIndex < rowCount ? columnIndex : 0][rowIndex < columnCount ? rowIndex : 0];
                }
            }

            int[,] mainDiagonalSum = new int[rowCount + 1, columnCount + 1];
            int[,] antiDiagonalSum = new int[rowCount + 1, columnCount + 2];

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    mainDiagonalSum[rowIndex + 1, columnIndex + 1] = mainDiagonalSum[rowIndex, columnIndex] + grid[rowIndex][columnIndex];
                    antiDiagonalSum[rowIndex + 1, columnIndex] = antiDiagonalSum[rowIndex, columnIndex + 1] + grid[rowIndex][columnIndex];
                }
            }

            int largestMagicSquareSize = 1;

            for (int squareSize = 2; squareSize <= Math.Min(rowCount, columnCount); squareSize++)
            {
                for (int topRow = 0; topRow + squareSize <= rowCount; topRow++)
                {
                    for (int leftColumn = 0; leftColumn + squareSize <= columnCount; leftColumn++)
                    {
                        int targetSum = rowPrefixSum[topRow][leftColumn + squareSize] - rowPrefixSum[topRow][leftColumn];
                        bool isMagicSquare = true;

                        for (int rowOffset = 0; rowOffset < squareSize && isMagicSquare; rowOffset++)
                        {
                            if (rowPrefixSum[topRow + rowOffset][leftColumn + squareSize] - rowPrefixSum[topRow + rowOffset][leftColumn] != targetSum)
                            {
                                isMagicSquare = false;
                            }
                        }

                        for (int columnOffset = 0; columnOffset < squareSize && isMagicSquare; columnOffset++)
                        {
                            int columnSum = 0;
                            for (int rowOffset = 0; rowOffset < squareSize; rowOffset++)
                            {
                                columnSum += grid[topRow + rowOffset][leftColumn + columnOffset];
                            }

                            if (columnSum != targetSum)
                            {
                                isMagicSquare = false;
                            }
                        }

                        int mainDiagonalSumValue = mainDiagonalSum[topRow + squareSize, leftColumn + squareSize] - mainDiagonalSum[topRow, leftColumn];
                        int antiDiagonalSumValue = antiDiagonalSum[topRow + squareSize, leftColumn] - antiDiagonalSum[topRow, leftColumn + squareSize];

                        if (isMagicSquare && mainDiagonalSumValue == targetSum && antiDiagonalSumValue == targetSum)
                        {
                            largestMagicSquareSize = squareSize;
                        }
                    }
                }
            }

            return largestMagicSquareSize;
        }
    }
}